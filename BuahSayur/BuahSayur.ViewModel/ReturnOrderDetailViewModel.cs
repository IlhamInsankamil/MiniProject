using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public decimal ReturnAmount { get; set; }

        public decimal Replacement { get; set; }
    }
}
