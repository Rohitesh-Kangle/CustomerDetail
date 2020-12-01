using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientDetail.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error

        public ViewResult Index()
        {
            return View("Error");
        }
        public ActionResult NotFound()
        {
            return View();
        }
    }
}