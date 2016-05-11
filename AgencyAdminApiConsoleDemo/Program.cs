using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace AgencyAdminApiConsoleDemo
{
    /// <summary>
    /// 
    /// Simplified demo showing how to use the Four Walls API to get the latest listings in your agency.
    /// 
    /// You'll need an active Agency account with Agency Admin privileges and a client system account.
    /// 
    /// By default, accounts will not have client system access.
    /// Please contact your Four Walls representative to get set up. 
    /// 
    /// FourWalls uses OAuth2 Bearer tokens to secure the API.
    /// 
    /// Replace the tokenRequestParams values with your details. 
    /// Build and run. 
    /// The console will echo the access_token once received and loop thru
    /// any listings found in your Agency account.
    /// 
    /// 
    /// This demo uses Flurl to call REST services
    /// https://tmenier.github.io/Flurl/
    /// 
    /// </summary>
    public class Program
    {

        static void Main(string[] args)
        {
            //string server = "http://test.four-walls.com";
            
            string server = "http://localhost:47913";

            var tokenRequestParams = new TokenRequestParams
            {                
                username = "your@email.com",
                password = "password",
                grant_type = "password",
                client_id = "someClientId",
                client_secret = "your secret phrase"
            };


            var demo = new Demo(server);
            demo.Run(tokenRequestParams).Wait();
        }
    }

}

