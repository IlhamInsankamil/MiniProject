using BuahSayur.DataModel;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.DataAccess
{
    public class SellingDataAccess
    {
        public static string Message = string.Empty;

        public static SellingResult Save(DeliveryOrderHeaderViewModel models)
        {
            SellingResult result = new SellingResult();

            try
            {
                using (var db = new BuahSayurContext())
                {
                    string newRef = GetNewReference();
                    result.Reference = newRef;

                    DeliveryOrder deliveryOrder = new DeliveryOrder
                    {
                        Id = 1,
                        Customer_Username = models.Customer_Username,
                        Reference = newRef,
                        SellingDate = models.SellingDate
                    };
                    db.DeliveryOrders.Add(deliveryOrder);

                    foreach (var item in models.DeliveryDetails)
                    {
                        DeliveryOrderDetail deliveryDetail = new DeliveryOrderDetail
                        {
                            DeliveryOrder_Id = deliveryOrder.Id,
                            Item_Code = item.Item_Code,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            Total = item.Quantity * item.Price
                        };
                        result.Total += (item.Quantity * item.Price);
                        db.DeliveryOrderDetails.Add(deliveryDetail);
                        // Update Stock
                        Item Stock = db.Items.Where(x => x.Code == item.Item_Code).FirstOrDefault();
                        if (Stock != null)
                        {
                            Stock.Stock = Stock.Stock - item.Quantity;
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                Message = ex.Message;
            }
            return result;
        }

        public static string GetNewReference()
        {
            string result = string.Empty;

            try
            {
                using (var db = new BuahSayurContext())
                {
                    var refTemplate = "DO-" + (DateTime.Now).ToString("yy") + string.Format("{0:00}", DateTime.Now.Month) + "-";

                    var lastRef = (from po in db.DeliveryOrders
                                   where po.Reference.Contains(refTemplate)
                                   select new { Id = po.Id, Reference = po.Reference }).OrderByDescending(o => o.Reference).FirstOrDefault();

                    int increment = 1;
                    if (lastRef != null)
                    {
                        string[] splitRef = lastRef.Reference.Split('-');
                        increment = int.Parse(splitRef[2]) + 1;
                    }
                    result = refTemplate + increment.ToString("D4");
                }
            }
            catch (Exception ex)
            {
                //Message = ex.Message;
                throw;
            }

            return result;
        }

        public static DeliveryOrderHeaderViewModel SelectedDeliveryOrder = new DeliveryOrderHeaderViewModel();

        public static DeliveryOrderHeaderViewModel GetByReference(string reference)
        {
            DeliveryOrderHeaderViewModel result = new DeliveryOrderHeaderViewModel();

            using (var db = new BuahSayurContext())
            {
                result = (from dOr in db.DeliveryOrders
                          join c in db.Customers
                            on dOr.Customer_Username equals c.Username into clf
                          from c in clf.DefaultIfEmpty()
                          where dOr.Reference == reference
                          select new DeliveryOrderHeaderViewModel
                          {
                              Id = dOr.Id,
                              Customer_Username = c.Username,
                              Reference = dOr.Reference,
                              SellingDate = dOr.SellingDate
                          }).FirstOrDefault();
            }
            return result;
        }

        public static DeliveryOrderHeaderViewModel SelectedSelling = new DeliveryOrderHeaderViewModel();

        //public static bool SetSelectedSelling(string reference)
        //{
        //    bool result = true;

        //    try
        //    {
        //        using (var db = new BuahSayurContext())
        //        {
        //            DeliveryOrder dOr = db.DeliveryOrders.Where(o => o.Reference == reference).FirstOrDefault();
        //            SelectedSelling.Id = dOr.Id;
        //            SelectedSelling.Customer_Username = dOr.Customer_Username;
        //            SelectedSelling.Reference = dOr.Reference;
        //            SelectedSelling.SellingDate = dOr.SellingDate;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result = false;
        //        Message = ex.Message;
        //    }

        //    return result;
        //}

        public static List<DeliveryOrderHeaderViewModel> GetByFilter(string filterString)
        {
            List<DeliveryOrderHeaderViewModel> result = new List<DeliveryOrderHeaderViewModel>();

            using (var db = new BuahSayurContext())
            {
                result = (from dOr in db.DeliveryOrders
                          join c in db.Customers
                            on dOr.Customer_Username equals c.Username
                          select new DeliveryOrderHeaderViewModel
                          {
                              Id = dOr.Id,
                              Customer_Username = c.Username,
                              Reference = dOr.Reference,
                              SellingDate = dOr.SellingDate
                          }).ToList();

                result = result.Where(o => o.Reference.ToLower().Contains(filterString.ToLower()) || o.Customer_Username.ToLower().Contains(filterString.ToLower())).ToList();
            }

            return result;
        }
        //public static bool SetSelectedDeliveryOrder(string reference)
        //{
        //    bool result = true;

        //    try
        //    {
        //        using (var db = new BuahSayurContext())
        //        {
        //            DeliveryOrder dOr = db.DeliveryOrders.Where(o => o.Reference == reference).FirstOrDefault();
        //            // melimpahkan dari Data Model ke View Model
        //            SelectedDeliveryOrder.Id = dOr.Id;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result = false;
        //        Message = ex.Message;
        //        throw;
        //    }

        //    return result;
        //}
    }
}
