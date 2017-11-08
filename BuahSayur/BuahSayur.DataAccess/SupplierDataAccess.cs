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

        public static SupplierViewModel GetById(int id) // to find id for delete method and edit in SupplierController
        {
            SupplierViewModel result = new SupplierViewModel();

            using (var db = new BuahSayurContext())
            {
                result = (from s in db.Suppliers
                          join c in db.Cities
                            on s.City_Code equals c.Code into clf
                          from c in clf.DefaultIfEmpty()
                          join p in db.Provinces
                            on c.Province_Code equals p.Code into plf
                          from p in plf.DefaultIfEmpty()
                          where s.Id == id
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
                              //Created = s.Created,
                              //CreatedBy = s.CreatedBy,
                              //Modified = s.Modified,
                              //ModifiedBy = s.ModifiedBy
                          }).FirstOrDefault();
            }
            return result;
        }

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
                            City_Code = model.City_Code,
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
                            supplier.City_Code = model.City_Code;
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
