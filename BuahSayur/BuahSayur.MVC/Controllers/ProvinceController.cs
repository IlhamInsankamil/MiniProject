using BuahSayur.DataAccess;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuahSayur.MVC.Controllers
{
    public class ProvinceController : Controller
    {
        // GET: Province
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(ProvinceDataAccess.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProvinceViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult CreateEdit(ProvinceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ProvinceDataAccess.Update(model))
                    {
                        return Json(new { success = true, message = "success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { succes = false, message = ProvinceDataAccess.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Please full fill required fields" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(int id)
        {
            return View(ProvinceDataAccess.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(ProvinceViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult Delete(int id)
        {
            return View(ProvinceDataAccess.GetById(id));
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (ProvinceDataAccess.Delete(id))
            {
                return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = ProvinceDataAccess.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}