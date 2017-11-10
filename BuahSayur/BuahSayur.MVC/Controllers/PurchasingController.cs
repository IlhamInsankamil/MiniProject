using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuahSayur.MVC.Controllers
{
    public class PurchasingController : Controller
    {
        // GET: Purchasing
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerForm()
        {
            return View();
        }
    }
}