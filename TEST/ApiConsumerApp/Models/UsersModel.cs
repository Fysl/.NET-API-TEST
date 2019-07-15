using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiConsumerApp.Models
{
    public class UsersModel
    {
        public int ID { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Please enter Cell No")]
        public int Cell { get; set; }
        [Required(ErrorMessage = "Please enter Email ID")]
        public string MailAddress { get; set; }
        public string City { get; set; }
    }
}