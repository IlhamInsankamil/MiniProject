﻿using BuahSayur.DataAccess;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuahSayur.MVC.Controllers
{
    public class SellingController : Controller
    {
        // GET: Selling
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerForm()
        {
            return View();
        }

        public ActionResult SellingList()
        {
            List<DeliveryOrderDetailViewModel> model = new List<DeliveryOrderDetailViewModel>();
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveSelling(DeliveryOrderHeaderViewModel models)
        {
            if (ModelState.IsValid)
            {
                SellingResult result = SellingDataAccess.Save(models);

                if (result.Success)
                {
                    return Json(new { success = true, message = "Success", data = result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = SellingDataAccess.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid Model State!" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSellingByReference(string reference)
        {
            DeliveryOrderHeaderViewModel model = SellingDataAccess.GetByReference(reference);

            if (model != null)
            {
                string SellingDate = model.SellingDate.ToString("ddd, dd/MM/yyyy");
                return Json(new { success = true, data = model, SellingDate = SellingDate }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult FilterList(string filterString)
        {
            return View(SellingDataAccess.GetByFilter(filterString));
        }
    }
}