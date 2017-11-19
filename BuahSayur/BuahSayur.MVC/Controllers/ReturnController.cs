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
            List<DeliveryOrderDetailViewModel> models =  ReturnDataAccess.GetSellingDetailByReference(reference);
            return View("ReturnList" , models);
        }

        [HttpPost]
        public ActionResult SaveRequestReturn(ReturnOrderHeaderViewModel models)
        {
            if (ModelState.IsValid)
            {
                ReturnResult result = ReturnDataAccess.Save(models);

                if (result.Success)
                {
                    return Json(new { success = true, message = "Success", data = result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = ReturnDataAccess.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid Model State!" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterList(string filterString)
        {
            //List<DeliveryOrderHeaderViewModel> models = new List<DeliveryOrderHeaderViewModel>();
            return View(ReturnDataAccess.GetByFilter(filterString));
        }
    }
}