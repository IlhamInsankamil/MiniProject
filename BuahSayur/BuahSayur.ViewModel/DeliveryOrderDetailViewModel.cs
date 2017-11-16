using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class DeliveryOrderDetailViewModel
    {
        public int Id { get; set; }

        public int DeliveryOrder_Id { get; set; }

        [DisplayName("Item Code")]
        public string Item_Code { get; set; }

        [DisplayName("Item Name")]
        public string Item_Name { get; set; }

        [DisplayName("Weight")]
        public string Item_Weight { get; set; }

        public string Item_Stock { get; set; }

        [DisplayName("Return Amount")]
        public decimal ReturnAmount { get; set; }

        public decimal? Replacement { get; set; }

        public decimal? Shortage { get; set; }

        public string Status { get; set; }

        public DateTime? Created { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal? Total { get; set; }
    }
}
