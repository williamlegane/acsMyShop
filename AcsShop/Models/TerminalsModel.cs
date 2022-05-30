using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcsShop.Models
{
    public class TerminalsModel
    {
        [Display(Name = "ID:")]
        public String Id { get; set; }
        [Display(Name = "Serial Number:")]
        public String SerialNumber { get; set; }
        [Display(Name = "Active:")]
        public Boolean Active { get; set; }
    }
}