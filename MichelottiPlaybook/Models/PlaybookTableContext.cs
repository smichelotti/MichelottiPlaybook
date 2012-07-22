using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace MichelottiPlaybook.Models
{
    public class PlaybookTableContext : TableServiceContext
    {
        public PlaybookTableContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }

        public IQueryable<PlayCategory> PlayCategories
        {
            get
            {
                return this.CreateQuery<PlayCategory>("PlayCategories");
            }
        }

        public IQueryable<Play> Plays
        {
            get
            {
                return this.CreateQuery<Play>("Plays");
            }
        }

        public IQueryable<User> Users
        {
            get
            {
                return this.CreateQuery<User>("Users");
            }
        }

        public IQueryable<UserActivity> UserActivities
        {
            get 
            {
                return this.CreateQuery<UserActivity>("UserActivities");
            }
        }
    }
}