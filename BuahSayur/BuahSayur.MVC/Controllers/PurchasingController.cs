using BuahSayur.DataAccess;
using BuahSayur.ViewModel;
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

        public ActionResult SupplierForm()
        {
            return View();
        }

        public ActionResult PurchasingList()
        {
            List<PurchasingOrderDetailViewModel> model = new List<PurchasingOrderDetailViewModel>();
            return View(model);
        }

        [HttpPost]
        public ActionResult SavePurchasing(PurchasingOrderHeaderViewModel models)
        {
            if (ModelState.IsValid)
            {
                PurchasingResult result = PurchasingDataAccess.Save(models);

                if (result.Success)
                {
                    return Json(new { success = true, message = "Success", data = result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = PurchasingDataAccess.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid Model State!" }, JsonRequestBehavior.AllowGet);
        }
    }
}