using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FormDemo.Models;

namespace FormDemo.DAL
{
    public class FormInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FormContext>
    {
        protected override void Seed(FormContext context)
        {
            var newsletterSignUps = new List<FormModel>
            {
                new FormModel{ ID="carraghr@gmail.com", hearAboutSource="Advert",signupReason="none"}
            };
            newsletterSignUps.ForEach(s => context.NewsletterSignUps.Add(s));
            context.SaveChanges();

            var availableHearAboutOptions = new List<string>(new string[] { "Advert", "Word of Mouth", "Other" });
            var hearAboutOptions = new List<HearAboutOptionModel>
            {
                new HearAboutOptionModel{ ID="Advert",EmptyString=""},
                new HearAboutOptionModel{ ID="Word of Mouth",EmptyString=""},
                new HearAboutOptionModel{ ID="Other",EmptyString=""},
            };
            hearAboutOptions.ForEach(s => context.HearAboutOptions.Add(s));
            context.SaveChanges();

        }
    }
}