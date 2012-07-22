using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MichelottiPlaybook.Models;
using MichelottiPlaybook.Services;
using Microsoft.IdentityModel.Claims;


namespace MichelottiPlaybook.Security
{
    public class RequireAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
    {
        private IUserRepository userRepository;

        //public RequireAuthenticationAttribute(IUserRepository repository)
        //{
        //    this.userRepository = repository;
        //}

        public void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                var url = filterContext.HttpContext.Request.Url;
                var redirectUrl = string.Format("{0}://{1}/", url.Scheme, url.Authority);
                //filterContext.Result = new RedirectResult("https://michelotti-apps.accesscontrol.windows.net:443/v2/wsfederation?wa=wsignin1.0&wtrealm=" + redirectUrl);
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {{ "Controller", "Account" }, { "Action", "SignIn" }, { "Area", "" } });
            }
            else
            {
                // User *is* authenticated so check to see if they are approved
                var identity = filterContext.HttpContext.User.Identity as IClaimsIdentity;
                var approvedClaim = identity.Claims.Where(c => c.ClaimType == "PlaybookApproved").SingleOrDefault();
                
                if (approvedClaim == null || approvedClaim.Value != "true")
                {
                    var nameIdClaim = identity.Claims.SingleOrDefault(c => c.ClaimType == ClaimTypes.NameIdentifier);
                    //var emailClaim = identity.Claims.SingleOrDefault(c => c.ClaimType == ClaimTypes.Email);

                    //TODO: need dependency injection for RequireAuthenticationAttribute
                    this.userRepository = new UserRepository();
                    var user = userRepository.GetUserByUserId(nameIdClaim.Value);
                    if (user != null && user.IsApproved)
                    {
                        // Add custom claim
                        identity.Claims.Add(new Claim("PlaybookApproved", "true"));

                        if (user.Permissions != null)
                        {
                            identity.Claims.Add(new Claim("Permissions", user.Permissions));
                        }
                        
                        userRepository.InsertUserActivity(new UserActivity { UserId = nameIdClaim.Value, Name = user.Name, Action = "Authenticate" });
                    }
                    else
                    {
                        // User is not in repository or hasn't been approved yet so redirect to Approval Screen
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            action = "ApprovalRequired",
                            controller = "Account",
                            area = ""
                        }));
                        
                    }
                }
            }
        }
    }
}