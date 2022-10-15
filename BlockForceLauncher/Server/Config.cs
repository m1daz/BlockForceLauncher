using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockForceLauncher.Server
{
    internal class Config
    {
        public static string SERVER_IP = "20.51.248.209";
        public static int SERVER_PORT = 7351;

        public static class AuthEndpoints
        {
            public static string AUTH_URL = "v2/console/api/endpoints/AuthenticateEmail";
        }
    }
}
