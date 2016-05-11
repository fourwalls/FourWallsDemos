using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace AgencyAdminApiConsoleDemo
{
    /// <summary>
    /// Parameters passes to the token request endpoints
    /// 
    /// GET /api/v1/token
    /// </summary>
    public class TokenRequestParams
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }

    }

}