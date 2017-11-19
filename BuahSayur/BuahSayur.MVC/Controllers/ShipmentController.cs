using BuahSayur.DataAccess;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuahSayur.MVC.Controllers
{
    public class ShipmentController : Controller
    {
        // GET: Shipment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DeliveryForm()
        {
            return View();
        }
        public ActionResult GetSellingDetailByReference(string reference)
        {
            List<DeliveryOrderDetailViewModel> models = ShipmentDataAccess.GetSellingDetailByReference(reference);
            return View("ShippingList", models);
        }
        [HttpPost]
        public ActionResult SaveShipment(ShipmentOrderViewModel models)
        {
            if (ModelState.IsValid)
            {

                if (ShipmentDataAccess.SaveShipment(models))
                {
                    return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = ShipmentDataAccess.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid Model State!" }, JsonRequestBehavior.AllowGet);
        }
    }
}