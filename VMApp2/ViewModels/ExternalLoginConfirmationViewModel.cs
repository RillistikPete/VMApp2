using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VMApp2.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Driver's License")]
        public string DriverLicense { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}