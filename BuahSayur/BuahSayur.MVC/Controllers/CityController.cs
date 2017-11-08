using BuahSayur.DataAccess;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuahSayur.MVC.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(CityDataAccess.GetAll());
        }
        public ActionResult Create()
        {
            ViewBag.ProvinceList = new SelectList(ProvinceDataAccess.GetAll(), "Code", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(CityViewModel model)
        {
            return CreateEdit(model);
        }
        public ActionResult CreateEdit(CityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CityDataAccess.Update(model))
                    {
                        return Json(new { success = true, message = "success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { succes = false, message = CityDataAccess.Message }, JsonRequestBehavior.AllowGet);
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
            ViewBag.ProvinceList = new SelectList(ProvinceDataAccess.GetAll(), "Code", "Name");
            return View(CityDataAccess.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(CityViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult Delete(int id)
        {
            return View(CityDataAccess.GetById(id));
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (CityDataAccess.Delete(id))
            {
                return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = CityDataAccess.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}