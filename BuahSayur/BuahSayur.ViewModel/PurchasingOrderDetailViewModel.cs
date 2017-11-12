using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class PurchasingOrderDetailViewModel
    {
        public int Id { get; set; }

        public int PurchasingOrder_Id { get; set; }

        [DisplayName("Code")]
        public string Item_Code { get; set; }

        [DisplayName("Item")]
        public string Item_Name { get; set; }

        [DisplayName("Weight")]
        public string Item_Weight { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal? Total { get; set; }
    }
}
