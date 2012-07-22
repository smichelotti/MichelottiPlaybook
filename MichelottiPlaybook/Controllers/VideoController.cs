using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichelottiPlaybook.Models;
using MichelottiPlaybook.Security;

namespace MichelottiPlaybook.Controllers
{
    [RequireAuthentication]
    public class VideoController : Controller
    {
        private IPlayCategoryRepository categoryRepository;

        public VideoController(IPlayCategoryRepository repository)
        {
            this.categoryRepository = repository;
        }

        public ActionResult Index(string categorySlug)
        {
            var playCategory = this.categoryRepository.FindBySlug(categorySlug);
            if (playCategory == null)
            {
                return this.HttpNotFound();
            }
            return View(playCategory);
        }
    }
}
