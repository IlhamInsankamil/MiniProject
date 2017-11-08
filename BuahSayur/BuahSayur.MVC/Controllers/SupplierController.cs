using BuahSayur.DataAccess;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuahSayur.MVC.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(SupplierDataAccess.GetAll());
        }

        //public ActionResult Create() 
        //{
        //    ViewBag.ProvinceList = new SelectList(ProvinceDataAccess.GetAll(), "Code", "Name");
        //    ViewBag.CityList = new SelectList(DepartmentDataAccess.GetByDivision(""), "Code", "Description");
        //    ViewBag.JobPositionList = new SelectList(JobPositionDataAccess.GetByDepartment(""), "Code", "Description");
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(EmployeeViewModel model)
        //{
        //    return CreateEdit(model);
        //}

        //public ActionResult Edit(int id)
        //{
        //    EmployeeViewModel model = EmployeeDataAccess.GetById(id);
        //    ViewBag.DivisionList = new SelectList(DivisionDataAccess.GetAll(), "Code", "Description");
        //    ViewBag.DepartmentList = new SelectList(DepartmentDataAccess.GetByDivision(model.DivisionCode), "Code", "Description");
        //    ViewBag.JobPositionList = new SelectList(JobPositionDataAccess.GetByDepartment(model.DepartmentCode), "Code", "Description");

        //    //return View(EmployeeDataAccess.GetById(id));
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Edit(EmployeeViewModel model)
        //{
        //    return CreateEdit(model);
        //}

        //public ActionResult CreateEdit(SupplierViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (SupplierDataAccess.Update(model))
        //            {
        //                return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                return Json(new { success = false, message = SupplierDataAccess.Message }, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            return Json(new { success = false, message = "Please full fill required fields!" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //public ActionResult Delete(int id)
        //{
        //    return View(EmployeeDataAccess.GetById(id));
        //}

        //[HttpPost]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    if (EmployeeDataAccess.Delete(id))
        //    {
        //        return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { success = false, message = EmployeeDataAccess.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}