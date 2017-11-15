using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class ReturnOrderHeaderViewModel
    {
        public int Id { get; set; }

        [DisplayName("DeliveryOrder Id")]
        public int DeliveryOrder_Id { get; set; }

        public string Reference { get; set; }

        [DisplayName("Return Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime ReturnDate { get; set; }

        public List<ReturnOrderDetailViewModel> ReturnOrderDetails { get; set; }
    }

    public class ReturnResult
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
