using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace BlockForceLauncher
{
    public partial class Form1 : Form
    {
        WebClient wc = new WebClient();
        string current_version;
        string current_beta;

        string file_beta;
        string file_release;
        public Form1()
        {
            InitializeComponent();
        }

        bool has_version_files()
        {
            if (Directory.Exists("files"))
            {
                if (File.Exists(@"files\release.txt"))
                {
                    if (File.Exists(@"files\beta.txt"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        bool create_files()
        {
            if (Directory.Exists("files"))
            {
                if (File.Exists(@"files\release.txt"))
                {
                    if (File.Exists(@"files\beta.txt"))
                    {
                        return true;
                    }
                    else
                    {
                        File.Create(@"files\beta.txt");
                        return create_files();
                    }
                }
                else
                {
                    File.Create(@"files\release.txt");
                    return create_files();
                }
            }
            else
            {
                Directory.CreateDirectory("files");
                return create_files();
            }
        }

        string get_local_beta_version()
        {
            if (File.Exists(@"files\release.tzt"))
                return File.ReadAllText(@"files\release.txt");
            else
                return "";
        }

        string get_local_release_version()
        {
            if (File.Exists(@"files\release.tzt"))
                return File.ReadAllText(@"files\release.txt");
            else
                return "";
        }

        void check_for_updates(string cv, string cb, string fb, string fr)
        {
            if (cv != get_local_release_version())
            {
                if (get_local_release_version() == "")
                {

                }
                else
                {
                    MessageBox.Show("Outdated Release Version Installed, Launch a release version to update!", "Block Force Remastered");
                }
            }
            if (cb != get_local_beta_version())
            {
                if (get_local_beta_version() == "")
                {

                }
                else
                {
                    MessageBox.Show("Outdated Beta Version Installed, Launch a release version to update!", "Block Force Remastered");
                }
            }
        }

        bool is_up_to_date(int type)
        {
            switch (type)
            {
                case 0:
                    return (current_version == get_local_release_version());
                case 1:
                    return (current_beta == get_local_beta_version());
                default:
                    return (current_version == get_local_release_version());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            current_version = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/current-release");
            current_beta = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/current-beta");

            file_beta = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/beta-file");
            file_release = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/release-file");
            this.comboVersion.SelectedIndex = 0;
            if (get_local_release_version() != "")
            {
                label1.Text = get_local_release_version();
            }
            if (has_version_files())
            {
                // Check for updates
                check_for_updates(current_version, current_beta, file_beta, file_release);
            }
            else
            {
                if (create_files())
                {
                    check_for_updates(current_version, current_beta, file_beta, file_release);
                }
                else
                {
                    MessageBox.Show("Error checking files, try deleting the \"Files\" folder and try again!");
                    Application.Exit();
                }
            }
        }

        void write_release_version()
        {
            File.WriteAllText(@"files\release.txt", current_version);
        }

        void write_beta_version()
        {
            File.WriteAllText(@"files\beta.txt", current_beta);
        }

        void launch_release()
        {
            if (!is_up_to_date(0))
            {
                if (File.Exists(@"files/BlockForceRelease.exe"))
                {
                    File.Delete(@"files/BlockForceRelease.exe");
                }
                button1.Enabled = false;
                label1.Text = "Updating...";
                wc.DownloadFile(file_release, @"files/BlockForceRelease.exe");
                label1.Text = "Launching...";
                Process.Start(@".\files\BlockForceRelease.exe");
                label1.Text = "V" + current_version;
                write_release_version();
                button1.Enabled = true;

            }
            else
            {
                button1.Enabled = false;
                label1.Text = "Launching...";
                Process.Start(@".\files\BlockForceRelease.exe");
                label1.Text = "V" + current_version;
                write_release_version();
                button1.Enabled = true;
            }
        }

        void launch_beta()
        {
            if (!is_up_to_date(1))
            {
                if (File.Exists(@"files/BlockForceBeta.exe"))
                {
                    File.Delete(@"files/BlockForceBeta.exe");
                }
                button1.Enabled = false;
                label1.Text = "Updating...";
                wc.DownloadFile(file_beta, @"files/BlockForceBeta.exe");
                label1.Text = "Launching...";
                Process.Start(@".\files\BlockForceBeta.exe");
                label1.Text = "V" + current_beta;
                write_beta_version();
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                label1.Text = "Launching...";
                Process.Start(@".\files\BlockForceBeta.exe");
                label1.Text = "V" + current_beta;
                write_beta_version();
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (this.comboVersion.SelectedIndex) {
                case 0:
                    launch_release();
                    break;
                case 1:
                    launch_beta();
                    break;
                default:
                    launch_release();
                    break;
            }
        }

        private void comboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboVersion.SelectedIndex)
            {
                case 0:
                    if (get_local_release_version() != "")
                    {
                        label1.Text = get_local_release_version();
                    }
                    break;
                case 1:
                    if (get_local_beta_version() != "")
                    {
                        label1.Text = get_local_beta_version();
                    }
                    break;
                default:
                    if (get_local_release_version() != "")
                    {
                        label1.Text = get_local_release_version();
                    }
                    break;
            }
        }
    }
}
