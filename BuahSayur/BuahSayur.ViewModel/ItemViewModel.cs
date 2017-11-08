using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        [DisplayName("Price (/pack)")]
        public decimal Price { get; set; }

        public string Category { get; set; }

        public decimal Stock { get; set; }

        public DateTime? Created { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }
    }
}
