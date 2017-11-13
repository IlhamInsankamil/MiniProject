using BuahSayur.DataModel;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.DataAccess
{
    public class ReturnDataAccess
    {
        public static string Message = string.Empty;

        public static bool Save(ReturnOrderHeaderViewModel models)
        {
            bool result = true;

            try
            {
                using (var db = new BuahSayurContext())
                {
                    ReturnOrder returnOrder = new ReturnOrder
                    {
                        Id = 1,
                        DeliveryOrder_Id = models.DeliveryOrder_Id,
                        ReturnDate = models.ReturnDate
                    };
                    db.ReturnOrders.Add(returnOrder);

                    foreach (var item in models.ReturnOrderDetails)
                    {
                        ReturnOrderDetail returnOrderDetail = new ReturnOrderDetail
                        {
                            Return_Id = returnOrder.Id,
                            ReturnAmount = item.ReturnAmount,
                            Replacement = item.Replacement
                        };
                        db.ReturnOrderDetails.Add(returnOrderDetail);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result = false;
                Message = ex.Message;
                //throw;
            }

            return result;
        }
    }
}
