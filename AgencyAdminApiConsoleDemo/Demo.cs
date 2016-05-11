using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace AgencyAdminApiConsoleDemo
{
    /// <summary>
    /// Main demo service.
    /// 
    /// Gets and access_token from FourWalls token api 
    /// and subsequently gets all listings for an agency using that access_token
    /// </summary>
    public class Demo
    {
        /// <summary>
        /// The base server url.
        /// 
        /// eg: https://test.four-walls.com
        /// </summary>
        string _server;
        

        public Demo(string server)
        {
            _server = server;
        }

        /// <summary>
        /// Main entry point to run the demo operations
        /// </summary>        
        public async Task Run(TokenRequestParams tokenRequestParams)
        {
            // Call the token endpoint with your TokenRequestParams to received a TokenResponse            
            var tokenResponse = await GetToken(tokenRequestParams);

            // Call the Agency Listings API 
            var listingsResponse = await GetListings(tokenResponse);


            
            Console.WriteLine(string.Format("Found {0} listings", listingsResponse.Listings.Count()));

            foreach(var listing in listingsResponse.Listings)
            {
                Console.WriteLine(listing.ListingStatusText);
            }
        }


        /// <summary>
        /// Perform a POST to /api/v1/token to get a json token response
        /// </summary>        
        protected async Task<TokenResponse> GetToken(TokenRequestParams p)
        {
            var tokenPath = _server + "/api/v1/token";

            var tokenResponse = await tokenPath
                .PostUrlEncodedAsync(p)
                .ReceiveJson<TokenResponse>()
                ;

            // The response contains an access_token that we will use to call other API endpoints
            Console.WriteLine(tokenResponse.access_token);

            return tokenResponse;
        }



        /// <summary>
        /// Perform a GET using an OAuthBearerToken to /api/v1/agency/listings/agency to get a json response
        /// of listings available in your Agency.
        /// 
        /// The raw request header should be:
        /// 
        /// Accept: application/json
        /// Content-Type: application/json
        /// Authorization: Bearer {{access_token}}
        /// 
        /// where {{access_token}} is the TokenResponse.access_token value
        /// </summary>        
        public async Task<AgencyListingsModel> GetListings(TokenResponse tokenResponse)
        {
            var serviceUri = _server + "/api/v1/agency/listings/agency";

            // We use the TokenResponse.access_token value to call API methods
            var response = await serviceUri
                .WithOAuthBearerToken(tokenResponse.access_token)
                .GetJsonAsync<AgencyListingsModel>();

            return response;
        }

        

        
    }

}