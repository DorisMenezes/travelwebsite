using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWebsite.model;
using MVCWebsite.db.DbOperations;

namespace MVCWebsite.Controllers
{
    public class HomeController : Controller
    {
        DestinationRepository destinationRepository = null;
        public HomeController()
        {
            destinationRepository = new DestinationRepository();
        }
        // GET: Home
        public ActionResult Index()
        {
            var result = destinationRepository.GetAllDest();
            return View(result);
        }

        public ActionResult AboutUs()
        {
            
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(DestinationModel model)
        {

            return View();
        }
       

    }
}