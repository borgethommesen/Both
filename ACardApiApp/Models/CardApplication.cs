using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardApplications.Models
{
    public class CardApplication
    {

    public int ID {get; set;}
    public string FirstName { get; set; }
    public string SurName { get; set; }
    public string CardName { get; set; }
    public string Gender { get; set; }
    public string DateOfBirth { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string Address { get; set; }
    public string CoAddress { get; set; }
    public string PostalCode { get; set; }
    public string PostalCity { get; set; }
    public string Country { get; set; }
    public string Language { get; set; }
    public string ProductID { get; set; }
    public string AccountAgreement { get; set; }
    public string Currency { get; set; }
    public string ApprovedAmount { get; set; }
    public double SpendingLimit { get; set; }
    public string Office { get; set; }
    public string HandlingOfficer { get; set; }
    public Boolean Status { get; set; }  
    }


}