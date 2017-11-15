using BuahSayur.DataAccess;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuahSayur.MVC.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(ItemDataAccess.GetAll());
        }

        public ActionResult Create()
        {
            //ViewBag.WeightList = new SelectList(ItemViewModel.GetWeightList(), "Value", "Display");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult Edit(int id)
        {
            //ViewBag.WeightList = new SelectList(ItemViewModel.GetWeightList(), "Value", "Display");
            return View(ItemDataAccess.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(ItemViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult CreateEdit(ItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ItemDataAccess.Update(model))
                    {
                        return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = ItemDataAccess.Message }, JsonRequestBehavior.AllowGet);
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
            return View(ItemDataAccess.GetById(id));
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            if (ItemDataAccess.Delete(id))
            {
                return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = ItemDataAccess.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ExceptionList(List<string> exceptionList) // display item by exception
        {
            return View(ItemDataAccess.GetByException(exceptionList));
        }

        public ActionResult ExceptionListMax(List<string> exceptionListMax) // display item by exception
        {
            return View(ItemDataAccess.GetByExceptionMax(exceptionListMax));
        }

        public ActionResult GetById(int id) // for select item
        {
            ItemViewModel model = ItemDataAccess.GetById(id);

            if (model != null)
            {
                return Json(new { success = true, data = model, message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, data = model, message = "Not found!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}