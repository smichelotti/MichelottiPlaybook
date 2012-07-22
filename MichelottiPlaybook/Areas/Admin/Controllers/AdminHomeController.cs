using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichelottiPlaybook.Security;

namespace MichelottiPlaybook.Areas.Admin.Controllers
{
    [RequireAuthentication]
    public class AdminHomeController : Controller
    {
        //
        // GET: /Admin/AdminHome/

        public ActionResult Index()
        {
            return View();
        }

    }
}
