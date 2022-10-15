using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockForceLauncher.Server.Auth
{
    internal class Token
    {
        private string token;
        private string refreshToken;
        private bool Functional;
        public Token(string token, string refreshToken, bool func=false)
        {
            this.token = token;
            this.refreshToken = refreshToken;
            this.Functional = func;
        }
        public Token()
        {
            this.token = "";
            this.refreshToken = "";
            this.Functional = false;
        }

        public void SetFunctional(bool func)
        {
            this.Functional = func;
        }

        public void SetToken(string token)
        {
            this.token = token;
        }
        public void SetRefreshToken(string refreshToken)
        {
            this.refreshToken = refreshToken;
        }
        public string GetToken()
        {
            return this.token;
        }

        public bool IsFunctional()
        {
            return this.Functional;
        }

        public string GetRefreshToken()
        {
            return this.refreshToken;
        }
    }
}
