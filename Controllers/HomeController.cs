using FormDemo.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FormDemo.Controllers
{
    public class HomeController : Controller
    {
        private DAL.FormContext db = new DAL.FormContext();

        [HttpPost]
        public ActionResult newsletterSignUp(FormModel model)
        {
            string status = System.String.Empty;
            string message = System.String.Empty;

            try
            {
                //check if email is valid
                var emailAddressCheck = new System.Net.Mail.MailAddress(model.ID);
                if (emailAddressCheck.Address.ToString() == model.ID)
                {
                    //check if email is already subscribed
                    if (db.NewsletterSignUps.Find(model.ID) == null)
                    {
                        //check if hear about option is valid
                        if(db.HearAboutOptions.Find(model.hearAboutSource) != null){
                            db.NewsletterSignUps.Add(model);
                            db.SaveChanges();
                            status = "Success";
                            message = "The email address " + model.ID + " has been subscribed to newsletter mailing list!";
                        }
                        else
                        {
                            status = "Error";
                            message = "The option " + model.hearAboutSource + " is not a valid choice!";
                        }
                    }
                    else
                    {
                        status = "Error";
                        message = "The email address " + model.ID + " is already subscribed to newsletter mailing list!";
                    }
                }
            }
            catch
            {
                status = "Error";
                message = "The email address " + model.ID + " is not a valid email address!";
            }

            return Json(new { status = status, message = message });
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}