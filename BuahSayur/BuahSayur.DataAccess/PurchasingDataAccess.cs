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
                    PurchasingOrder purchasingOrder = new PurchasingOrder
                    {
                        Id = 1,
                        Supplier_Code = models.Supplier_Code,
                        PurchasingDate = models.PurchasingDate
                    };
                    db.PurchasingOrders.Add(purchasingOrder);

                    foreach (var item in models.PurchasingDetails)
                    {
                        PurchasingOrderDetail sellingDetail = new PurchasingOrderDetail
                        {
                            PurchasingOrder_Id = purchasingOrder.Id,
                            Item_Code = item.Item_Code,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            Total = item.Quantity * item.Price
                        };
                        result.Total += (item.Quantity * item.Price);
                        db.PurchasingOrderDetails.Add(sellingDetail);
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
    }
}
