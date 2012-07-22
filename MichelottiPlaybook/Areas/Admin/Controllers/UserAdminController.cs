using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichelottiPlaybook.Models;
using MichelottiPlaybook.Security;

namespace MichelottiPlaybook.Areas.Admin.Controllers
{
    [RequireAuthentication]
    public class UserAdminController : Controller
    {
        private IUserRepository userRepository;

        public UserAdminController(IUserRepository repository)
        {
            this.userRepository = repository;
        }

        public ActionResult Index()
        {
            var users = this.userRepository.GetAllUsers();
            return View(users);
        }

        public ActionResult Approval(string userId, bool approval)
        {
            this.userRepository.SetUserApproval(userId, approval);
            return this.RedirectToAction("Index");
        }
    }
}
