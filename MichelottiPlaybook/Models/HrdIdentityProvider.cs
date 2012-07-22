using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MichelottiPlaybook.Models
{
    /// <summary>
    /// Identity Provider information in HRD JSON Feed
    /// </summary>
    public class HrdIdentityProvider
    {
        public string Name { get; set; }
        public string LoginUrl { get; set; }
        public string LogoutUrl { get; set; }
        public string ImageUrl { get; set; }
        public List<string> EmailAddressSuffixes { get; set; }
    }
}