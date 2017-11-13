using BuahSayur.DataModel;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.DataAccess
{
    public class CustomerDataAccess
    {
        public static string Message = string.Empty;
        public static List<CustomerViewModel> GetAll()
        {
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            using (var db = new BuahSayurContext())
            {
                result = (from cs in db.Customers
                          join ct in db.Cities
                          on cs.City_Code equals ct.Code
                          join pr in db.Provinces
                            on ct.Province_Code equals pr.Code
                          select new CustomerViewModel
                          {
                              Id = cs.Id,
                              Username = cs.Username,
                              FirstName = cs.FirstName,
                              LastName = cs.LastName,
                              Address = cs.Address,
                              PhoneNumber = cs.PhoneNumber,
                              Province_Code = pr.Code,
                              Province_Name = pr.Name,
                              City_Code = ct.Code,
                              City_Name = ct.Name,
                              IsActivated = ct.IsActivated
                          }).ToList();
            }
            return result;
        }
        public static CustomerViewModel GetById(int id)
        {
            CustomerViewModel result = new CustomerViewModel();

            using (var db = new BuahSayurContext())
            {
                result = (from cs in db.Customers
                          join ct in db.Cities
                           on cs.City_Code equals ct.Code into ctlf
                          from ct in ctlf.DefaultIfEmpty()
                          join pr in db.Provinces
                           on ct.Province_Code equals pr.Code into prlf
                          from pr in prlf.DefaultIfEmpty()
                          where cs.Id == id
                          select new CustomerViewModel
                          {
                              Id = cs.Id,
                              Username = cs.Username,
                              FirstName = cs.FirstName,
                              LastName = cs.LastName,
                              Address = cs.Address,
                              PhoneNumber = cs.PhoneNumber,
                              Province_Code = pr.Code,
                              Province_Name = pr.Name,
                              City_Code = ct.Code,
                              City_Name = ct.Name,
                              IsActivated = ct.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }
        public static bool Update(CustomerViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new BuahSayurContext())
                {
                    if (model.Id == 0)
                    {
                        Customer customer = new Customer
                        {
                            Username = model.Username,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Address = model.Address,
                            PhoneNumber = model.PhoneNumber,
                            City_Code = model.City_Code,
                            IsActivated = model.IsActivated,
                            Created = DateTime.Now,
                            CreatedBy = "Hasan"
                        };
                        db.Customers.Add(customer);
                        db.SaveChanges();
                    }
                    else
                    {
                        Customer customer = db.Customers.Where(o => o.Id == model.Id).FirstOrDefault();
                        if (customer != null)
                        {
                            customer.Username = model.Username;
                            customer.FirstName = model.FirstName;
                            customer.LastName = model.LastName;
                            customer.Address = model.Address;
                            customer.PhoneNumber = model.PhoneNumber;
                            customer.City_Code = model.City_Code;
                            customer.IsActivated = model.IsActivated;
                            customer.Modified = DateTime.Now;
                            customer.ModifiedBy = "Hasan";
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
                    Customer customer = db.Customers.Where(o => o.Id == id).FirstOrDefault();
                    if (customer != null)
                    {
                        db.Customers.Remove(customer);
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

        public static CustomerViewModel GetByUsername(string username)
        {
            CustomerViewModel result = new CustomerViewModel();

            using (var db = new BuahSayurContext())
            {
                result = (from cs in db.Customers
                          join c in db.Cities
                            on cs.City_Code equals c.Code into clf
                          from c in clf.DefaultIfEmpty()
                          join p in db.Provinces
                            on c.Province_Code equals p.Code into plf
                          from p in plf.DefaultIfEmpty()
                          where cs.Username == username
                          select new CustomerViewModel
                          {
                              Id = cs.Id,
                              Username = cs.Username,
                              FirstName = cs.FirstName,
                              LastName = cs.LastName,
                              Address = cs.Address,
                              PhoneNumber = cs.PhoneNumber,
                              Province_Code = p.Code,
                              Province_Name = p.Name,
                              City_Code = c.Code,
                              City_Name = c.Name,
                              IsActivated = cs.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }

        public static List<CustomerViewModel> GetByFilter(string filterString)
        {
            List<CustomerViewModel> result = new List<CustomerViewModel>();

            using (var db = new BuahSayurContext())
            {
                result = (from cs in db.Customers
                          join c in db.Cities
                            on cs.City_Code equals c.Code
                          join p in db.Provinces
                            on c.Province_Code equals p.Code
                          select new CustomerViewModel
                          {
                              Id = cs.Id,
                              Username = cs.Username,
                              FirstName = cs.FirstName,
                              LastName = cs.LastName,
                              Address = cs.Address,
                              PhoneNumber = cs.PhoneNumber,
                              Province_Code = p.Code,
                              Province_Name = p.Name,
                              City_Code = c.Code,
                              City_Name = c.Name,
                              IsActivated = cs.IsActivated
                          }).ToList();

                result = result.Where(o => o.Username.ToLower().Contains(filterString.ToLower()) || o.FullName.ToLower().Contains(filterString.ToLower()) || o.FullAddress.ToLower().Contains(filterString.ToLower())).ToList();
            }

            return result;
        }
    }
}
