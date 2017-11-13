using BuahSayur.DataModel;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.DataAccess
{
    public class ItemDataAccess
    {
        public static string Message = string.Empty;

        public static List<ItemViewModel> GetAll()
        {
            List<ItemViewModel> result = new List<ItemViewModel>();

            using (var db = new BuahSayurContext())
            {
                result = (from i in db.Items
                          select new ItemViewModel
                          {
                              Id = i.Id,
                              Code = i.Code,
                              Name = i.Name,
                              Price = i.Price,
                              Category = i.Category,
                              Stock = i.Stock,
                              Weight = i.Weight,
                              Size = i.Size,
                              IsActivated = i.IsActivated
                          }).ToList();
            }

            return result;
        }

        public static ItemViewModel GetById(int id)
        {
            ItemViewModel result = new ItemViewModel();

            using (var db = new BuahSayurContext())
            {
                result = (from i in db.Items
                          where i.Id == id
                          select new ItemViewModel
                          {
                              Id = i.Id,
                              Code = i.Code,
                              Name = i.Name,
                              Price = i.Price,
                              Category = i.Category,
                              Stock = i.Stock,
                              Weight = i.Weight,
                              Size = i.Size,
                              IsActivated = i.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static bool Update(ItemViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new BuahSayurContext())
                {
                    if (model.Id == 0)
                    {
                        Item item = new Item
                        {
                            Code = model.Code,
                            Name = model.Name,
                            Price = model.Price,
                            Category = model.Category,
                            Stock = model.Stock,
                            Weight = model.Weight,
                            Size = model.Size,
                            IsActivated = model.IsActivated,
                            Created = DateTime.Now,
                            CreatedBy = "Ilham",

                        };
                        db.Items.Add(item);
                        db.SaveChanges();
                    }
                    else
                    {
                        Item item = db.Items.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (item != null)
                        {
                            item.Code = model.Code;
                            item.Name = model.Name;
                            item.Price = model.Price;
                            item.Category = model.Category;
                            item.Stock = model.Stock;
                            item.Weight = model.Weight;
                            item.Size = model.Size;
                            item.IsActivated = model.IsActivated;
                            item.Modified = DateTime.Now;
                            item.ModifiedBy = "Ilham";
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
                    Item item = db.Items.Where(o => o.Id == id).FirstOrDefault();
                    if (item != null)
                    {
                        db.Items.Remove(item);
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

        public static List<ItemViewModel> GetByException(List<string> ExceptionList)
        {
            List<ItemViewModel> result = new List<ItemViewModel>();

            using (var db = new BuahSayurContext())
            {
                result = (from it in db.Items
                          select new ItemViewModel
                          {
                              Id = it.Id,
                              Code = it.Code,
                              Name = it.Name,
                              Price = it.Price,
                              Category = it.Category,
                              Stock = it.Stock,
                              Weight = it.Weight,
                              Size = it.Size,
                              IsActivated = it.IsActivated
                          }).Where(o => !ExceptionList.Contains(o.Code) && o.Stock > 0).ToList();
            }

            return result;
        }
    }
}
