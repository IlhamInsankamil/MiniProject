using BuahSayur.DataModel;
using BuahSayur.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.DataAccess
{
    public class ShipmentDataAccess
    {
        public static List<DeliveryOrderDetailViewModel> GetSellingDetailByReference(string reference)
        {
            List<DeliveryOrderDetailViewModel> result = new List<DeliveryOrderDetailViewModel>();

            //string sRef = SellingDataAccess.SelectedSelling.Reference;

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
                              Item_Weight = i.Weight,
                              Item_Size = i.Size,
                              Quantity = dod.Quantity,
                              Price = dod.Price,
                              Total = dod.Total
                          }).ToList();
            }

            return result;
        }

        public static string Message = string.Empty;
        public static bool SaveShipment(ShipmentOrderViewModel models)
        {

            bool result = true;
            try
            {
                using (var db = new BuahSayurContext())
                {
                    ShipmentOrder shipmentorder = new ShipmentOrder
                    {
                        Id = 1,
                        DeliveryOrder_Id = models.DeliveryOrder_Id,
                        ShippingDate = models.ShippingDate,
                        Vehicle = models.Vehicle,
                        PersonInCharge = models.PersonInCharge,
                        Fee = models.Fee
                    };
                    db.ShipmentOrders.Add(shipmentorder);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result = false;
                Message = ex.Message;
            }

            return result;
        }
    }
}
