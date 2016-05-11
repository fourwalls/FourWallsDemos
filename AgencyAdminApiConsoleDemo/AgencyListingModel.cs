using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace AgencyAdminApiConsoleDemo
{
    /// <summary>
    /// Partially represents an Agency Listing
    /// </summary>
    public class AgencyListingModel
    {
        public Guid Id { get; set; }
        public string Address { get; set; }

        public virtual string ListingStatusText { get; set; }
    }

}