using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MichelottiPlaybook.Models;
using MichelottiPlaybook.Services;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Web;

namespace MichelottiPlaybook.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserRepository userRepository;
        private IPlaybookEmailer emailer;
        private IHrdAgent hrdAgent;

        public AccountController(IUserRepository repository, IPlaybookEmailer emailer, IHrdAgent hrdAgent)
        {
            this.userRepository = repository;
            this.emailer = emailer;
            this.hrdAgent = hrdAgent;
        }

        [AllowAnonymous]
        public ActionResult SignIn()
        {
            var providers = this.hrdAgent.GetProviders(this.Request.Url.AbsoluteUri);
            var viewModel = providers.ToDictionary(x => x.Name);

            return View(viewModel);
        }

        /// <summary>
        /// This is the sign out method when using Azure ACS.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SignOut()
        {
            WSFederationAuthenticationModule fam = FederatedAuthentication.WSFederationAuthenticationModule;

            try
            {
                FormsAuthentication.SignOut();
            }
            finally
            {
                fam.SignOut(true);
            }

            // Return to home after LogOff
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ApprovalRequired()
        {
            var identity = this.User.Identity as IClaimsIdentity;
            var nameId = identity.Claims.GetValue(ClaimTypes.NameIdentifier);
            var user = this.userRepository.GetUserByUserId(nameId);
            
            return View(user);
        }

        [HttpPost]
        public ActionResult ApprovalRequired(User user)
        {
            if (ModelState.IsValid)
            {
                var identity = this.User.Identity as IClaimsIdentity;
                var nameId = identity.Claims.GetValue(ClaimTypes.NameIdentifier);
                var email = identity.Claims.GetValue(ClaimTypes.Email);
                user.UserId = nameId;
                user.Email = (email == null ? "(Windows Live)" : email);

                this.userRepository.InsertUser(user);
                this.emailer.SendApprovalRequestEmail(user.Name + " (" + user.Email + ")");

                return View(user);
            }
            else
            {
                return RedirectToAction("ApprovalRequired");
            }
        }
    }
}
