﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [DisplayName("Province")]
        public string Province_Code { get; set; }

        [DisplayName("Province")]
        public string Province_Name { get; set; }

        [DisplayName("City")]
        public string City_Code { get; set; }

        [DisplayName("City")]
        public string City_Name { get; set; }

        public DateTime? Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public string ModifiedBy { get; set; }
    }
}
