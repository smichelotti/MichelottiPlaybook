using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.StorageClient;

namespace MichelottiPlaybook.Models
{
    public class User : TableServiceEntity
    {
        public string UserId { get; set; }
        
        [Required]
        public string Name { get; set; }
        public bool IsApproved { get; set; }
        public string Email { get; set; }
        public string Permissions { get; set; }
    }
}