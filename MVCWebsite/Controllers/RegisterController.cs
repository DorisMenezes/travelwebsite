using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebsite.db;
using MVCWebsite.model;
using MVCWebsite.db.DbOperations;
using System.Web.Security;

namespace MVCWebsite.Controllers
{
    public class RegisterController : Controller
    {
        private TravelAgencyEntities db = new TravelAgencyEntities();
        DestinationRepository destinationRepository = null;
        public RegisterController()
        {
            destinationRepository = new DestinationRepository();
        }
        // GET: Register
      
       
        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientsModel clientsModel)
        {
            if (ModelState.IsValid)
            {
                var result=destinationRepository.AddClient(clientsModel);
                if (result > 0)
                {
                    ModelState.Clear();
                    return RedirectToAction("Create");
                }
            }

            return View();
        }

       
        // POST: Register/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Password,EmailId,FirstName,LastName,MobileNo,Address,City,State")] ClientsModel clientsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientsModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ClientsModel clientsModel)
        {
            if (ModelState.IsValid)
            {
                var result = destinationRepository.checkLogin(clientsModel);
                if (result)
                {
                    FormsAuthentication.SetAuthCookie(clientsModel.Username,false);
                    ModelState.Clear();
                    return RedirectToAction("Index","Home");
                }
            }
            ModelState.AddModelError("","Invalid username or password");
            return View();
        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
        // GET: Register/Delete/5
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
