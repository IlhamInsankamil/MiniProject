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

        [DisplayName("Supplier Code")]
        public string Supplier_Code { get; set; }

        //[DisplayName("Supplier Name")]
        //public string Supplier_Name { get; set; }

        //[DisplayName("Address")]
        //public string Supplier_FullAddress { get; set; }

        public string Reference { get; set; }

        [DisplayName("Purchasing Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime PurchasingDate { get; set; }

        // Detail
        public List<PurchasingOrderDetailViewModel> PurchasingDetails { get; set; }
    }

    public class PurchasingResult
    {
        private bool _Success = true;

        public bool Success
        {
            get { return _Success; }
            set { _Success = value; }
        }

        public string Reference { get; set; }
        public decimal Total { get; set; }
    }
}
