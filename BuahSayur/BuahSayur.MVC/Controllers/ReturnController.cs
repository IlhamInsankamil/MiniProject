using BuahSayur.DataAccess;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuahSayur.MVC.Controllers
{
    public class ReturnController : Controller
    {
        // GET: Return
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSellingDetailByReference(string reference)
        {
            List<DeliveryOrderDetailViewModel> models = ReturnDataAccess.GetSellingDetailByReference(reference);
            return View("ReturnList" , models);
        }
    }
}