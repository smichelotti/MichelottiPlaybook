using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MichelottiPlaybook.Security;

namespace MichelottiPlaybook.Controllers
{
    [RequireAuthentication]
    public class PracticesController : Controller
    {
        //
        // GET: /Practices/

        public ActionResult Index()
        {
            return View();
        }

    }
}
