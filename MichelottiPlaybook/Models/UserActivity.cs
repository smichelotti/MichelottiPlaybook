using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.StorageClient;

namespace MichelottiPlaybook.Models
{
    public class UserActivity : TableServiceEntity
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
    }
}