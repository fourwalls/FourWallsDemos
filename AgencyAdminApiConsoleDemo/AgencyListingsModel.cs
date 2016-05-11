using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace AgencyAdminApiConsoleDemo
{
    /// <summary>
    /// The response object from /api/v1/agency/listings/agency
    /// </summary>
    public class AgencyListingsModel
    {
        public List<AgencyListingModel> Listings { get; set; }
    }

}