﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class DeliveryOrderHeaderViewModel
    {
        // Header
        public int Id { get; set; }

        [DisplayName("Username")]
        public string Customer_Username { get; set; }

        public string Reference { get; set; }

        [DisplayName("Selling Date"), DisplayFormat(DataFormatString = "{0:ddd, dd/MM/yyyy}")]
        public DateTime SellingDate { get; set; }

        [DisplayName("Shipping Date"), DisplayFormat(DataFormatString = "{0:ddd, dd/MM/yyyy}")]
        public DateTime ShippingDate { get; set; }


        public string SellingDateString 
        { 
            get 
            {
                return SellingDate.ToString("ddd, dd/MM/yyyy");
            } 
        }

        public bool IsSent { get; set; }

        public bool IsReturned { get; set; }

        // Detail
        public List<DeliveryOrderDetailViewModel> DeliveryDetails { get; set; }
    }

    public class SellingResult
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
