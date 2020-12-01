using ClientDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Configuration;

namespace ClientDetail.Controllers
{
    public class CustomerController : Controller
    {
        string WebApiUrl = Convert.ToString(ConfigurationManager.AppSettings["WebApiUrl"]);

        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<CustomerInformation> objCust = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApiUrl);
                var responseTask = client.GetAsync("api/CustomerInformations");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CustomerInformation>>();
                    readTask.Wait();
                    objCust = readTask.Result;
                }
                else
                {
                    objCust = Enumerable.Empty<CustomerInformation>();
                    ModelState.AddModelError(string.Empty, "Error. Please contact administrator.");
                }
            }
            return View(objCust);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveCustomerInfo(CustomerInformation custData)
        {
            using (var client = new HttpClient())
            {
                custData.Status = true;
                client.BaseAddress = new Uri(WebApiUrl);
                var PostJob = client.PostAsJsonAsync<CustomerInformation>("api/CustomerInformations", custData);
                var result = PostJob.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            CustomerInformation objCust = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApiUrl);
                var responseTask = client.GetAsync("api/CustomerInformations/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CustomerInformation>();
                    readTask.Wait();
                    objCust = readTask.Result;
                }
            }
            return View(objCust);
        }

        [HttpPost]
        public ActionResult UpdateCustomerInfo(CustomerInformation custData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApiUrl);
                var putTask = client.PutAsJsonAsync<CustomerInformation>("api/CustomerInformations/" + custData.CustID + "/", custData);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(custData);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            CustomerInformation objCust = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApiUrl);
                var responseTask = client.GetAsync("api/CustomerInformations/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CustomerInformation>();
                    readTask.Wait();
                    objCust = readTask.Result;
                }
            }
            return View(objCust);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCustomerInfo(int? id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApiUrl);
                var deleteTask = client.DeleteAsync("api/CustomerInformations/" + id.ToString() + "?status=" + false);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}