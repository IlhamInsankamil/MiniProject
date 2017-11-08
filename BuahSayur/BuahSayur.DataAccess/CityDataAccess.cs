using BuahSayur.DataModel;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.DataAccess
{
    public class CityDataAccess
    {
        public static string Message = string.Empty;

        public static List<CityViewModel> GetAll()
        {
            List<CityViewModel> result = new List<CityViewModel>();

            using (var db = new BuahSayurContext())
            {
                result = (from ct in db.Cities
                          join p in db.Provinces 
                          on ct.Province_Code equals p.Code
                          select new CityViewModel
                          {
                              Id = ct.Id,
                              Code = ct.Code,
                              Province_Code = ct.Province_Code,
                              ProvinceName = p.Name,
                              Name = ct.Name,
                              PostalCode = ct.PostalCode
                          }).ToList();
            }

            return result;
        }
        public static bool Update(CityViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new BuahSayurContext())
                {
                    if (model.Id == 0)
                    {
                        City city = new City
                        {
                            Code = model.Code,
                            Province_Code = model.Province_Code,
                            Name = model.Name,
                            PostalCode = model.PostalCode,
                            Created = DateTime.Now,
                            CreatedBy = "Hasan",

                        };
                        db.Cities.Add(city);
                        db.SaveChanges();
                                           
                    }
                    else
                    {
                        City city = db.Cities.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (city != null)
                        {
                            city.Code = model.Code;
                            city.Province_Code = model.Province_Code;
                            city.Name = model.Name;
                            city.PostalCode = model.PostalCode;
                            city.Modified = DateTime.Now;
                            city.ModifiedBy = "Hasan";
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
        public static CityViewModel GetById(int id)
        {
            CityViewModel result = new CityViewModel();
            using (var db = new BuahSayurContext())
            {
                result = (from ct in db.Cities
                          join p in db.Provinces
                          on ct.Province_Code equals p.Code
                          where ct.Id == id
                          select new CityViewModel
                          {
                              Id = ct.Id,
                              Code = ct.Code,
                              Province_Code = ct.Province_Code,
                              ProvinceName = p.Name,
                              Name = ct.Name,
                              PostalCode = ct.PostalCode
                          }).FirstOrDefault();
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
                    City city = db.Cities.Where(o => o.Id == id).FirstOrDefault();
                    if (city != null)
                    {
                        db.Cities.Remove(city);
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
        public static List<CityViewModel> GetByProvince(string provinceCode)
        {
            List<CityViewModel> result = new List<CityViewModel>();

            using (var db = new BuahSayurContext())
            {
                result = (from ct in db.Cities
                          join p in db.Provinces
                              on ct.Province_Code equals p.Code
                          where ct.Province_Code == provinceCode
                          select new CityViewModel
                          {
                              Id = ct.Id,
                              Code = ct.Code,
                              Province_Code = ct.Province_Code,
                              Name = ct.Name,
                              PostalCode = ct.PostalCode
                          }).ToList();
            }
            return result;
        }
    }
}
