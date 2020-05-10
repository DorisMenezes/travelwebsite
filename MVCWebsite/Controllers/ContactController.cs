using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWebsite.model;
using System.Net.Mail;
using MVCWebsite.db.DbOperations;

namespace MVCWebsite.Controllers
{
    public class ContactController : Controller
    {
        DestinationRepository destinationRepository = null;
        public ContactController()
        {
            destinationRepository = new DestinationRepository();
        }
        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(ContactModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.EmailSent = false;
                    MailMessage mail = new MailMessage();
                    mail.To.Add("pace.doris96@gmail.com");
                    mail.From = new MailAddress(model.Email);
                    mail.Subject = model.Subject;
                    mail.Body = model.MessageBody;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("pace.doris96@gmail.com", "pace.doris@123"); // Enter seders User name and password  
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    model.EmailSent = true;
                    var result = destinationRepository.AddContacts(model);
                    if (result > 0)
                    {
                        ModelState.Clear();
                        return RedirectToAction("Create");
                    }

                    
                }
               
                return View();
        }
            catch
            {
                ModelState.AddModelError("", "Email was not sent");
                return View();
    }
}

        
      
       
    }
}
