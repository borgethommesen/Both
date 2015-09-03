using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using CardApplications.Models;
using ACardApiApp.Models;

namespace CardApplications.Controllers
{
    public class CardApplicationController : ApiController
    {
        [HttpGet]
        public IEnumerable<CardApplication> Get()
        {
            using (var db = new ACardApiAppContext())
            {
                var query = from b in db.CardApplications
                            where b.Status == false
                            orderby b.CardName
                            select b;

                if (query.Count() <= 0)
                {
                    //Returnera en tom objekt i de fall det inte finns några 
                    //Cardapplications att föra över
                    var CardApplicationObjects = new CardApplication[1];
                    var application = new CardApplication();
                    CardApplicationObjects[0] = application;
                    return CardApplicationObjects;
                }
                else
                {
                    var CardApplicationObjects = new CardApplication[query.Count()];
                    int i = 0;
                    foreach (var item in query)
                    {
                        if (item.Status == false)
                        {
                            var application = new CardApplication();
                            application.ID = item.ID;
                            application.AccountAgreement = item.AccountAgreement;
                            application.Address = item.Address;
                            application.ApprovedAmount = item.ApprovedAmount;
                            application.CoAddress = item.CoAddress;
                            application.Country = item.Country;
                            application.Currency = item.Currency;
                            application.DateOfBirth = item.DateOfBirth;
                            application.CardName = item.CardName;
                            application.FirstName = item.FirstName;
                            application.SurName = item.SurName;
                            application.Gender = item.Gender;
                            application.HandlingOfficer = item.HandlingOfficer;
                            application.Language = item.Language;
                            application.Office = item.Office;
                            application.PostalCity = item.PostalCity;
                            application.PostalCode = item.PostalCode;
                            application.ProductID = item.ProductID;
                            application.SocialSecurityNumber = item.SocialSecurityNumber;
                            application.SpendingLimit = item.SpendingLimit;

                            CardApplicationObjects[i] = application;
                            i++;

                            // updatera status= true=överförd, false=ej överförd
                            var ApplicationStatus = db.CardApplications.Find(item.ID);
                            ApplicationStatus.Status = true;
                        }
                    }
                    db.SaveChanges();
                    return CardApplicationObjects;
                }
            }

        }

    }
}
