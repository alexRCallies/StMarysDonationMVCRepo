using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace StMarys_Donor
{
    public class DonorAPIClient
    {
        public DonorAPIClient(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; set; }
    }
}
