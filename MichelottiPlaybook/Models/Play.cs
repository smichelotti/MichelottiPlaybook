using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.StorageClient;

namespace MichelottiPlaybook.Models
{
    public class Play : TableServiceEntity
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Uri { get; set; }
    }
}