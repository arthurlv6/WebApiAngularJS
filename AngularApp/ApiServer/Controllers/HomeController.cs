using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApiServer.DataContext.Models;
using Newtonsoft.Json;

namespace ApiServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Help", new { Area = "" });
            ViewBag.Title = "Home Page";
            return View();
        }
        public async Task<ActionResult> Test()
        {
            var data = new Product(){Cost = 1200,Price = 1300,CreateDate = DateTime.Now,Name = "Goods",ProductCode = "AABCCC"};
            string link = "api/Products";
            string json = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await GetClient().PostAsync(link, content);
            if (response.IsSuccessStatusCode)
            {
                var ret = response.Content.ReadAsStringAsync();
                if (ret.Result == "success")
                {
                    ViewBag.Message = "successfully passed.";
                    return View();
                }
                else
                {
                    ViewBag.Message = "return false";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "response failed.";
                return View();
            }
        }
        private static HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("testHeader", "tokenArthur");
            client.BaseAddress = new Uri("http://localhost:7737/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
