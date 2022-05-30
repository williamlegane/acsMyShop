using AcsShop.Http;
using AcsShop.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcsShop.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            ViewBag.Message = "";

            try
            {
                String merchantNo = "000000000001959";
                String httpResult = await HttpClientRequest.createGetRequest("https://api-uat.acs-sa.com/Merchant/" + merchantNo, "Bearer", getToken());
                if (httpResult.IndexOf(merchantNo) > -1)
                {
                    JObject json = JObject.Parse(httpResult);
                    ProfileModel pm = new ProfileModel();
                    pm.City = (String)json["city"];
                    pm.CountryCode = (String)json["countryCode"];
                    pm.MechantNumber = (String)json["merchantNumber"];
                    pm.RegionCode = (String)json["regionCode"];
                    pm.ShopName = (String)json["shopName"];
                    pm.Street = (String)json["merchantStreetAddress"];
                    return View(pm);
                }
                else {
                    ViewBag.Message = "No profile data...";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Something went wrong";
            }

            return View();
        }


        private String getToken()
        {
            return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBY2Nlc3NLZXkiOiIzNzJkMWY5NC02NWRiLTQ1OGItODZiOC0wZjNlYmZmY2MxOGYiLCJuYmYiOjE2MzkwNTA0MTAsImV4cCI6NDc5NDcyNDAxMCwiaWF0IjoxNjM5MDUwNDEwfQ.ipX__X7E5Q9xaxGI_Sb5AeiZgpWRMNnPJUXgFVbeEHY";
        }
    }
}