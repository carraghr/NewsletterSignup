using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormDemo.Models
{
    public class FormModel
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string ID { get; set; }
        [DisplayName("Where did you hear about us")]
        public string hearAboutSource { get; set; }
        [DisplayName("Reason for singup")]
        public string signupReason { get; set; }
    }
}