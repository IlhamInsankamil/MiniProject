using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class ShipmentOrderViewModel
    {
        public int Id { get; set; }

        public int DeliveryOrder_Id { get; set; }

        [DisplayName("Shipping Date"), DisplayFormat(DataFormatString = "{0:ddd, dd/MM/yyyy}")]
        public DateTime ShippingDate { get; set; }

        public string Vehicle { get; set; }

        [DisplayName("Person In Charge")]
        public string PersonInCharge { get; set; }

        public decimal? Fee { get; set; }

        public decimal Item_Size { get; set; }
        public decimal Item_Weight { get; set; }
    }
}
