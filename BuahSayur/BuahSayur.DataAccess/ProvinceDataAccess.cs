using BuahSayur.DataModel;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.DataAccess
{
    public class ProvinceDataAccess
    {
        public static string Message = string.Empty;

        public static List<ProvinceViewModel> GetAll()
        {
            List<ProvinceViewModel> result = new List<ProvinceViewModel>();

            using (var db = new BuahSayurContext())
            {
                result = (from p in db.Provinces
                          select new ProvinceViewModel
                          {
                              Id = p.Id,
                              Code = p.Code,
                              Name = p.Name,
                          }).ToList();
            }

            return result;
        }

        public static bool Update(ProvinceViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new BuahSayurContext())
                {
                    if (model.Id == 0)
                    {
                        Province province = new Province
                        {
                            Code = model.Code,
                            Name = model.Name,
                            Created = DateTime.Now,
                            CreatedBy = "Hasan",

                        };
                        db.Provinces.Add(province);
                        db.SaveChanges();
                    }
                    else
                    {
                        Province province = db.Provinces.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (province != null)
                        {
                            province.Code = model.Code;
                            province.Name = model.Name;
                            province.Modified = DateTime.Now;
                            province.ModifiedBy = "Hasan";
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
                    Province province = db.Provinces.Where(o => o.Id == id).FirstOrDefault();
                    if (province != null)
                    {
                        db.Provinces.Remove(province);
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
        public static ProvinceViewModel GetById(int id)
        {
            ProvinceViewModel result = new ProvinceViewModel();
            using (var db = new BuahSayurContext())
            {
                result = (from p in db.Provinces
                          where p.Id == id
                          select new ProvinceViewModel
                          {
                              Id = p.Id,
                              Code = p.Code,
                              Name = p.Name,
                          }).FirstOrDefault();
            }
            return result;
        }

    }
}
