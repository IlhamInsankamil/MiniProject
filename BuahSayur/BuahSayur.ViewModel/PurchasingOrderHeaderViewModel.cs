using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class PurchasingOrderHeaderViewModel
    {
        // Header
        public int Id { get; set; }

        public string Supplier_Code { get; set; }

        public string Reference { get; set; }

        [DisplayName("Purchasing Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime PurchasingDate { get; set; }

        // Detail
        public List<PurchasingOrderDetailViewModel> PurchasingDetails { get; set; }
    }
}
