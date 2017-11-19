using BuahSayur.DataModel;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.DataAccess
{
    public class PurchasingDataAccess
    {
        public static string Message = string.Empty;

        public static PurchasingResult Save(PurchasingOrderHeaderViewModel models)
        {
            PurchasingResult result = new PurchasingResult();

            try
            {
                using (var db = new BuahSayurContext())
                {
                    string newRef = GetNewReference();
                    result.Reference = newRef;

                    PurchasingOrder purchasingOrder = new PurchasingOrder
                    {
                        Id = 1,
                        Supplier_Code = models.Supplier_Code,
                        Reference = newRef,
                        PurchasingDate = models.PurchasingDate
                    };
                    db.PurchasingOrders.Add(purchasingOrder);

                    foreach (var item in models.PurchasingDetails)
                    {
                        PurchasingOrderDetail purchasingDetail = new PurchasingOrderDetail
                        {
                            PurchasingOrder_Id = purchasingOrder.Id,
                            Item_Code = item.Item_Code,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            Total = item.Quantity * item.Price
                        };
                        result.Total += (item.Quantity * item.Price);
                        db.PurchasingOrderDetails.Add(purchasingDetail);
                        // Update Stock
                        Item Stock = db.Items.Where(x => x.Code == item.Item_Code).FirstOrDefault();
                        if (Stock!=null)
                        {
                            Stock.Stock = Stock.Stock + item.Quantity;
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
                    var refTemplate = "PO-" + (DateTime.Now).ToString("yy") + string.Format("{0:00}", DateTime.Now.Month) + "-";

                    var lastRef = (from po in db.PurchasingOrders
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
                Message = ex.Message;
                //throw;
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
                            IsActivated = model.IsActivated,
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
                            supplier.IsActivated = model.IsActivated;
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
    }
}
