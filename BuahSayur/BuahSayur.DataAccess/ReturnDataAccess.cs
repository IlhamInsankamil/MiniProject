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

        public static List<DeliveryOrderDetailViewModel> GetSellingDetailByReference(string reference)
        {
            List<DeliveryOrderDetailViewModel> result = new List<DeliveryOrderDetailViewModel>();

            //string sRef = SellingDataAccess.SelectedSelling.Reference;

            using (var db = new BuahSayurContext())
            {
                result = (from dod in db.DeliveryOrderDetails
                          join doh in db.DeliveryOrders
                            on dod.DeliveryOrder_Id equals doh.Id
                          where doh.Reference == reference
                          select new DeliveryOrderDetailViewModel
                          {
                              Id = dod.Id,
                              DeliveryOrder_Id = doh.Id,
                              Item_Code = dod.Item_Code,
                              Quantity = dod.Quantity,
                              Price = dod.Price,
                              Total = dod.Total
                          }).ToList();
            }

            return result;
        }

        //public static bool Save(List<ItemViewModel> models)
        //{
        //    bool result = true;

        //    try
        //    {
        //        int doId = SellingDataAccess.SelectedDeliveryOrder.Id;
        //        using (var db = new BuahSayurContext())
        //        {
        //            foreach (var model in models)
        //            {
        //                //Item iExist = db.Items.Where();
        //            }
        //            //ReturnOrder returnOrder = new ReturnOrder
        //            //{
        //            //    Id = 1,
        //            //    DeliveryOrder_Id = models.DeliveryOrder_Id,
        //            //    ReturnDate = models.ReturnDate
        //            //};
        //            //db.ReturnOrders.Add(returnOrder);

        //            //foreach (var item in models.ReturnOrderDetails)
        //            //{
        //            //    ReturnOrderDetail returnOrderDetail = new ReturnOrderDetail
        //            //    {
        //            //        Return_Id = returnOrder.Id,
        //            //        ReturnAmount = item.ReturnAmount,
        //            //        Replacement = item.Replacement
        //            //    };
        //            //    db.ReturnOrderDetails.Add(returnOrderDetail);
        //            //}
        //            //db.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result = false;
        //        Message = ex.Message;
        //        //throw;
        //    }

        //    return result;
        //}
    }
}
