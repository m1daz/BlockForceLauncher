using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BlockForceLauncher.Server.Auth
{
    internal class Login
    {
        private string username = "";
        private string password = "";
        private string email = "";
        private bool inputtedEmail = false;
        private static readonly HttpClient client = new HttpClient();
        public Login(string username, string password, string email="")
        {
            this.username = username.Trim();
            this.password = password.Trim();
            if (email != "")
            {
                this.inputtedEmail = true;
                this.email = email.Trim();
            }
            else
            {
                this.inputtedEmail = false;
            }
        }

        public Token GetToken()
        {
            Token token = new Token();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + Config.SERVER_IP + ":" + Config.SERVER_PORT + "/" + Config.AuthEndpoints.AUTH_URL);
            MessageBox.Show("http://" + Config.SERVER_IP + ":" + Config.SERVER_PORT + "/" + Config.AuthEndpoints.AUTH_URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"account\": {\"email\": \""+this.email+"\",\"password\": \""+this.password+"\"},\"create\": false,\"username\": \""+this.username+"\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                try
                {
                    dynamic stuff = JsonConvert.DeserializeObject(result);
                    token = new Token(stuff.token, stuff.refreshToken, true);
                }catch(Exception e)
                {

                }
            }
            return token;
        }
    }
}
