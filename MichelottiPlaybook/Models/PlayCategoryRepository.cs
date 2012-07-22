using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace MichelottiPlaybook.Models
{
    public class PlayCategoryRepository : IPlayCategoryRepository
    {
        private PlaybookTableContext context = ContextFactory.CreateContext();

        public PlayCategory FindBySlug(string categorySlug)
        {
            var category = this.context.PlayCategories.Where(x => x.Slug == categorySlug).FirstOrDefault();
            category.Plays = this.context.Plays.Where(x => x.PartitionKey == category.Name).ToList().OrderBy(x => x.Order).ToList();

            return category;
        }
    }

    public interface IPlayCategoryRepository
    {
        PlayCategory FindBySlug(string categorySlug);
    }
}