using BuahSayur.DataAccess;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuahSayur.MVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(CustomerDataAccess.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.ProvinceList = new SelectList(ProvinceDataAccess.GetAll(), "Code", "Name");
            ViewBag.CityList = new SelectList(CityDataAccess.GetByProvince(""), "Code", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult Edit(int id)
        {
            CustomerViewModel model = CustomerDataAccess.GetById(id);

            ViewBag.ProvinceList = new SelectList(ProvinceDataAccess.GetAll(), "Code", "Name");
            ViewBag.CityList = new SelectList(CityDataAccess.GetByProvince(model.Province_Code), "Code", "Name"); 
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult CreateEdit(CustomerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CustomerDataAccess.Update(model))
                    {
                        return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = CustomerDataAccess.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Please full fill required fields!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            return View(CustomerDataAccess.GetById(id));
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (CustomerDataAccess.Delete(id))
            {
                return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = CustomerDataAccess.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}