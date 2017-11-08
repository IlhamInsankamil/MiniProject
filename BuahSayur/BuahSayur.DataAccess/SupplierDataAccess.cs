using BuahSayur.DataModel;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.DataAccess
{
    public class SupplierDataAccess
    {
        public static string Message = string.Empty;

        public static List<SupplierViewModel> GetAll()
        {
            List<SupplierViewModel> result = new List<SupplierViewModel>();

            using (var db = new BuahSayurContext())
            {
                result = (from s in db.Suppliers
                          join c in db.Cities
                            on s.City_Code equals c.Code
                          join p in db.Provinces
                            on c.Province_Code equals p.Code
                          select new SupplierViewModel
                          {
                              Id = s.Id,
                              Code = s.Code,
                              Name = s.Name,
                              Address = s.Address,
                              Province_Code = p.Code,
                              Province_Name = p.Name,
                              City_Code = c.Code,
                              City_Name = c.Name
                          }).ToList();
            }

            return result;
        }

        //public static SupplierViewModel GetById(int id) // to find id for delete method
        //{
        //    SupplierViewModel result = new SupplierViewModel();

        //    using (var db = new KaryawanContext())
        //    {
        //        result = (from em in db.Employees
        //                  join jp in db.JobPositions
        //                    on em.JobPositionCode equals jp.Code into jplf
        //                  from jp in jplf.DefaultIfEmpty()
        //                  join dp in db.Departments
        //                    on jp.DepartmentCode equals dp.Code into dplf
        //                  from dp in dplf.DefaultIfEmpty()
        //                  join dv in db.Divisions
        //                    on dp.DivisionCode equals dv.Code into dvlf
        //                  from dv in dvlf.DefaultIfEmpty()
        //                  where em.Id == id
        //                  select new SupplierViewModel
        //                  {
        //                      Id = em.Id,
        //                      BadgeId = em.BadgeId,
        //                      DivisionCode = dv.Code,
        //                      DepartmentCode = dp.Code,
        //                      JobPositionCode = em.JobPositionCode,
        //                      JobPositionName = jp.Description,
        //                      FirstName = em.FirstName,
        //                      MiddleName = em.MiddleName,
        //                      LastName = em.LastName,
        //                      Address = em.Address,
        //                      DateOfHire = em.DateOfHire,
        //                      DateOfResign = em.DateOfResign,
        //                      PlaceOfBirth = em.PlaceOfBirth,
        //                      DateOfBirth = em.DateOfBirth,
        //                      Gender = em.Gender,
        //                      IsActived = em.IsActived
        //                  }).FirstOrDefault();
        //    }
        //    return result;
        //}

        public static bool Update(SupplierViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new BuahSayurContext())
                {
                    if (model.Id == 0)
                    {
                        Supplier supplier = new Supplier
                        {
                            Code = model.Code,
                            Name = model.Name,
                            Address = model.Address,
                            City_Code = model.City_Name,
                            Created = DateTime.Now,
                            CreatedBy = "Ilham"
                        };
                        db.Suppliers.Add(supplier);
                        db.SaveChanges();
                    }
                    else
                    {
                        Supplier supplier = db.Suppliers.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (supplier != null)
                        {
                            supplier.Code = model.Code;
                            supplier.Name = model.Name;
                            supplier.Address = model.Address;
                            supplier.City_Code = model.City_Name;
                            supplier.Modified = DateTime.Now;
                            supplier.ModifiedBy = "Ilham";
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                result = false;
            }
            return result;
        }

        public static bool Delete(int id)
        {
            bool result = true;
            try
            {
                using (var db = new BuahSayurContext())
                {
                    Supplier supplier = db.Suppliers.Where(o => o.Id == id).FirstOrDefault();
                    if (supplier != null)
                    {
                        db.Suppliers.Remove(supplier);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                result = false;
            }
            return result;
        }
    }
}
