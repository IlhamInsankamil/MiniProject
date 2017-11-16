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

            using (var db = new BuahSayurContext())
            {
                result = (from dod in db.DeliveryOrderDetails
                          join doh in db.DeliveryOrders
                            on dod.DeliveryOrder_Id equals doh.Id
                          join i in db.Items
                            on dod.Item_Code equals i.Code
                          where doh.Reference == reference
                          select new DeliveryOrderDetailViewModel
                          {
                              Id = dod.Id,
                              DeliveryOrder_Id = doh.Id,
                              Item_Code = dod.Item_Code,
                              Item_Name = i.Name,
                              Quantity = dod.Quantity,
                              Price = dod.Price,
                              Total = dod.Total
                          }).ToList();
            }

            return result;
        }

        public static ReturnResult Save(ReturnOrderHeaderViewModel models)
        {
            ReturnResult result = new ReturnResult();

            try
            {
                using (var db = new BuahSayurContext())
                {
                    string newRef = GetNewReference();
                    result.Reference = newRef;

                    ReturnOrder returnOrder = new ReturnOrder
                    {
                        Id = 1,
                        DeliveryOrder_Id = models.DeliveryOrder_Id,
                        Reference = newRef,
                        ReturnDate = models.ReturnDate
                    };
                    db.ReturnOrders.Add(returnOrder);

                    foreach (var item in models.ReturnOrderDetails)
                    {
                        ReturnOrderDetail returnOrderDetail = new ReturnOrderDetail
                        {
                            Return_Id = returnOrder.Id,
                            Item_Code = item.Item_Code,
                            ReturnAmount = item.ReturnAmount
                        };
                        db.ReturnOrderDetails.Add(returnOrderDetail);
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
                    var refTemplate = "RO-" + (DateTime.Now).ToString("yy") + string.Format("{0:00}", DateTime.Now.Month) + "-";

                    var lastRef = (from ro in db.ReturnOrders
                                   where ro.Reference.Contains(refTemplate)
                                   select new { Id = ro.Id, Reference = ro.Reference }).OrderByDescending(o => o.Reference).FirstOrDefault();

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
