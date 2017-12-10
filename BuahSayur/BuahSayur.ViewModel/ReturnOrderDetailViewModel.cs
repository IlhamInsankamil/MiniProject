using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class ReturnOrderDetailViewModel
    {
        public int Id { get; set; }

        public int Return_Id { get; set; }

        [DisplayName("Return Amount")]
        public string Item_Code { get; set; }

        [DisplayName("Item Name")]
        public string Item_Name { get; set; }

        public decimal Quantity { get; set; }
        
        [Required]
        [DisplayName("Return Amount")]
        public decimal ReturnAmount { get; set; }

        public decimal Replacement { get; set; }

        public decimal Shortage { get; set; }

        public string Status { get; set; }
    }
}
