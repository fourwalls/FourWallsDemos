using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace AgencyAdminApiConsoleDemo
{

    public class TokenResponse
    {
        /// <summary>
        /// access_token is what you pass in as the Bearer token
        /// </summary>
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string userName { get; set; }
        public DateTime issued { get; set; }
        public DateTime expires { get; set; }

    }

}