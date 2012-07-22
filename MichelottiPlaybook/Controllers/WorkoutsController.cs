using System.Collections.Generic;
using System.Web.Mvc;
using MichelottiPlaybook.Models;
using MichelottiPlaybook.Security;

namespace MichelottiPlaybook.Controllers
{
    [RequireAuthentication]
    public class WorkoutsController : Controller
    {
        private IWorkoutsRepository repository;

        public WorkoutsController(IWorkoutsRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Guard()
        {
            var list = this.repository.GetGuardWorkouts();
            this.ViewData.Model = list;
            this.ViewBag.PageTitle = "Guard Workout";
            this.ViewBag.PageSubTitle = "Focus on Ball Handling and Form Shooting.";
            return View("PositionWorkout");
        }

        public ActionResult BigMan()
        {
            var list = this.repository.GetBigManWorkouts();
            this.ViewData.Model = list;
            this.ViewBag.PageTitle = "Big Man Workout";
            this.ViewBag.PageSubTitle = "Focus on Layups and Ball Handling.";
            return View("PositionWorkout");
        }
    }
}
