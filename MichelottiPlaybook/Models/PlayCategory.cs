using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.StorageClient;

namespace MichelottiPlaybook.Models
{
    public class PlayCategory : TableServiceEntity
    {
        public PlayCategory()
        {
            this.Plays = new List<Play>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<Play> Plays { get; set; }
        
        public string PlaysJson
        {
            get
            {
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string json = serializer.Serialize(this.Plays);
                return json;
            }
        }
    }
}