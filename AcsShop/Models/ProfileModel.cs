using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcsShop.Models
{
    public class ProfileModel
    {
        [Display(Name = "Shop Name:")]
        public String ShopName { get; set; }
        [Display(Name = "Mechant Number:")]
        public String MechantNumber { get; set; }
        [Display(Name = "Street:")]
        public String Street { get; set; }
        [Display(Name = "City:")]
        public String City { get; set; }
        [Display(Name = "Region Code:")]
        public String RegionCode { get; set; }
        [Display(Name = "Country Code:")]
        public String CountryCode { get; set; }
    }
}