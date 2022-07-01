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
using System.Threading;
using System.Net.Mime;

namespace BlockForceLauncher
{
    public partial class Form1 : Form
    {
        WebClient wc = new WebClient();
        string current_version;
        string current_beta;
        string[] dependencies;
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
                        File.WriteAllText(@"files\beta.txt", "");
                        return create_files();
                    }
                }
                else
                {
                    File.WriteAllText(@"files\release.txt", "");
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
            if (File.Exists(@"files\beta.txt"))
                using (StreamReader read = new StreamReader(@"files\beta.txt"))
                {
                    return read.ReadToEnd();
                }
            else
                return "";
        }

        string get_local_release_version()
        {
            if (File.Exists(@"files\release.txt"))
                using (StreamReader read = new StreamReader(@"files\release.txt"))
                {
                    return read.ReadToEnd();
                }
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
                    new Thread(() =>
                    {
                        MessageBox.Show("Outdated Release Version Installed, Launch a release version to update!", "Block Force Remastered");
                    }).Start();
                }
            }
            if (cb != get_local_beta_version())
            {
                if (get_local_beta_version() == "")
                {

                }
                else
                {
                    new Thread(() =>
                    {
                        MessageBox.Show("Outdated Beta Version Installed, Launch a release version to update!", "Block Force Remastered");
                    }).Start();
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
                if (get_local_release_version() != "") {
                    label1.Text = "V" + get_local_release_version();
                    if (current_version != get_local_release_version())
                    {
                        label1.ForeColor = Color.Red;
                    }
                    else
                    {
                        label1.ForeColor = Color.LightGreen;
                    }
                }
                else
                {
                    label1.Text = "V" + current_version;
                }
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
            current_version = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/current-release");
            current_beta = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/current-beta");

            file_beta = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/beta-file");
            file_release = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/release-file");
            if (!is_up_to_date(0))
            {
                if (File.Exists(@"files/BlockForceRelease.exe"))
                {
                    File.Delete(@"files/BlockForceRelease.exe");
                }
                button1.Enabled = false;
                label1.Text = "Updating...";
                mainProcess.Text = "Downloading Game";
                subProcess.Text = "Loading...";
                mainProcess.Visible = true;
                subProcess.Visible = true;
                downloadProgress.Visible = true;
                WebClient dlClient = new WebClient();
                downloadProgress.Value = 0;
                dlClient.DownloadProgressChanged += (s, e) =>
                {
                    double curProgress = Math.Round((e.BytesReceived / 1024.0 / 1024.0), 2);
                    double totalProgress = Math.Round((e.TotalBytesToReceive / 1024.0 / 1024.0), 2);
                    subProcess.Text = String.Format("{0}/{1} MB", curProgress, totalProgress);
                    downloadProgress.Value = e.ProgressPercentage;
                };
                dlClient.DownloadFileCompleted += (s, e) =>
                {
                    download_external_dependencies(0, false);
                    // any other code to process the file
                };
                dlClient.DownloadFileAsync(new Uri(file_release), @"files/BlockForceRelease.exe");
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
            current_version = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/current-release");
            current_beta = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/current-beta");

            file_beta = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/beta-file");
            file_release = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/release-file");
            if (!is_up_to_date(1))
            {
                if (File.Exists(@"files/BlockForceBeta.exe"))
                {
                    File.Delete(@"files/BlockForceBeta.exe");
                }
                button1.Enabled = false;
                label1.Text = "Updating...";
                mainProcess.Text = "Downloading Game";
                subProcess.Text = "Loading...";
                mainProcess.Visible = true;
                subProcess.Visible = true;
                downloadProgress.Visible = true;
                downloadProgress.Value = 0;
                WebClient dlClient = new WebClient();
                dlClient.DownloadProgressChanged += (s, e) =>
                {
                    double curProgress = Math.Round((e.BytesReceived / 1024.0 / 1024.0), 2);
                    double totalProgress = Math.Round((e.TotalBytesToReceive / 1024.0 / 1024.0), 2);
                    subProcess.Text = String.Format("{0}/{1} MB", curProgress, totalProgress);
                    downloadProgress.Value = e.ProgressPercentage;
                };
                dlClient.DownloadFileCompleted += (s, e) =>
                {
                    download_external_dependencies(1, false);
                };
                dlClient.DownloadFileAsync(new Uri(file_beta), @"files/BlockForceBeta.exe");
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
            label1.ForeColor = Color.White;
            switch (this.comboVersion.SelectedIndex)
            {
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

        public void download_external_dependencies(int ver, bool skip = false)
        {
            if (skip == false)
            {
                string stringResult = wc.DownloadString("https://raw.githubusercontent.com/generic-glitch/BlockForceLauncher/master/dependecies");
                dependencies = stringResult.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                label1.Text = "Downloading Dependencies";
                download_file(dependencies[0], (() =>
                {
                    dependencies = dependencies.Skip(1).ToArray();
                    download_external_dependencies(ver, true);
                }));
            }
            else if (skip && dependencies.Length < 1)
            {
                downloadProgress.Visible = false;
                mainProcess.Visible = false;
                subProcess.Visible = false;
                if (this.label1.InvokeRequired)
                {
                    this.label1.BeginInvoke((MethodInvoker)delegate () { this.label1.Text = "Launching..."; });
                }
                else
                {
                    this.label1.Text = "Launching...";
                }
                if (ver == 1)
                {
                    Process.Start(@".\files\BlockForceBeta.exe");
                    write_beta_version();
                }
                else
                {
                    Process.Start(@".\files\BlockForceRelease.exe");
                    write_release_version();
                }
                if (this.label1.InvokeRequired)
                {
                    this.label1.BeginInvoke((MethodInvoker)delegate () { this.label1.Text = "V" + current_version; });
                }
                else
                {
                    this.label1.Text = "V" + current_version;
                }
                if (this.button1.InvokeRequired)
                {
                    this.button1.BeginInvoke((MethodInvoker)delegate () { this.button1.Enabled = true; });
                }
                else
                {
                    this.button1.Enabled = true;
                }
                label1.ForeColor = Color.LightGreen;
            }
            else
            {
                download_file(dependencies[0], (() =>
                {
                    dependencies = dependencies.Skip(1).ToArray();
                    download_external_dependencies(ver, true);
                }));
            }
        }
        public delegate void DownloadCompleteCallback();
        public void download_file(string url, DownloadCompleteCallback dlComplCallback)
        {
            label1.Text = "Downloading Dependencies";
            WebClient dlClient = new WebClient();
            string file_name = GetFilenameFromWebServer(url);
            mainProcess.Text = file_name;
            subProcess.Text = "Loading...";
            mainProcess.Visible = true;
            subProcess.Visible = true;
            downloadProgress.Visible = true;
            downloadProgress.Value = 0;
            dlClient.DownloadProgressChanged += (s, e) =>
            {
                double curProgress = Math.Round((e.BytesReceived / 1024.0 / 1024.0), 2);
                double totalProgress = Math.Round((e.TotalBytesToReceive / 1024.0 / 1024.0), 2);
                subProcess.Text = String.Format("{0}/{1} MB", curProgress, totalProgress);
                downloadProgress.Value = e.ProgressPercentage;
            };
            dlClient.DownloadFileCompleted += (s, e) =>
            {
                dlComplCallback();
                // any other code to process the file
            };
            dlClient.DownloadFileAsync(new Uri(url), @"files/"+file_name);
        }

        public string GetFilenameFromWebServer(string url)
        {
            var uri = new Uri(url);
            string filename = uri.Segments.Last();
            return filename;
        }

        private void comboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboVersion.SelectedIndex)
            {
                case 0:
                    if (get_local_release_version() != "")
                    {
                        label1.Text = "V" + get_local_release_version();
                    }
                    else
                    {
                        label1.Text = "V" + current_version;
                    }
                    if (current_version != get_local_release_version())
                    {
                        label1.ForeColor = Color.Red;
                    }
                    else
                    {
                        label1.ForeColor = Color.LightGreen;
                    }
                    break;
                case 1:
                    if (get_local_beta_version() != "")
                    {
                        label1.Text = "V" + get_local_beta_version();
                    }
                    else
                    {
                        label1.Text = "V" + current_beta;
                    }
                    if (current_beta != get_local_beta_version())
                    {
                        label1.ForeColor = Color.Red;
                    }
                    else
                    {
                        label1.ForeColor = Color.LightGreen;
                    }
                    break;
                default:
                    if (get_local_release_version() != "")
                    {
                        label1.Text = "V" + get_local_release_version();
                    }
                    else
                    {
                        label1.Text = "V" + current_version;
                    }
                    if (current_version != get_local_release_version())
                    {
                        label1.ForeColor = Color.Red;
                    }
                    else
                    {
                        label1.ForeColor = Color.LightGreen;
                    }
                    break;
            }
        }
    }
}
