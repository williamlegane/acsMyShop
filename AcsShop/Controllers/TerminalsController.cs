using AcsShop.Http;
using AcsShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;



namespace AcsShop.Controllers
{
    public class TerminalsController : Controller
    {


        public async Task<ActionResult> Index()
        {
            ViewBag.Message = "";

            try
            {
                String merchantNo = "000000000001959";
                String httpResult = await HttpClientRequest.createGetRequest("https://api-uat.acs-sa.com/Terminal/Terminals/" + merchantNo, "Bearer", getToken());

                if (httpResult.IndexOf(merchantNo) > -1)
                {
                    JArray jsonArray = JArray.Parse(httpResult);

                    List<TerminalsModel> tmList = new List<TerminalsModel>();

                    foreach (var item in jsonArray)
                    {
                        tmList.Add(new TerminalsModel()
                        {
                            Active = (Boolean)item["termActive"],
                            Id = (String)item["id"],
                            SerialNumber = (String)item["serialNr"]
                        });
                    }
                    return View(tmList);
                }
                else {
                    ViewBag.Message = "No terminals data...";
                }
            } catch (Exception ex)
            {
                ViewBag.Message = "Something went wrong";
            }
 
            return View();
        }


        private String getToken() {
            return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBY2Nlc3NLZXkiOiIzNzJkMWY5NC02NWRiLTQ1OGItODZiOC0wZjNlYmZmY2MxOGYiLCJuYmYiOjE2MzkwNTA0MTAsImV4cCI6NDc5NDcyNDAxMCwiaWF0IjoxNjM5MDUwNDEwfQ.ipX__X7E5Q9xaxGI_Sb5AeiZgpWRMNnPJUXgFVbeEHY";
        }
    }
}