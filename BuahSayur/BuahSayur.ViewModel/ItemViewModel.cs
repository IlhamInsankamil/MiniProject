using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DisplayName("Category")]
        public string CategoryString
        {
            get
            {
                switch (Category)
                {
                    case "B":
                        return "Buah";
                    case "S":
                        return "Sayur";
                    default:
                        return "";
                }
            }
        }

        [DisplayName("Stock (pack)"), DisplayFormat(DataFormatString = "{0:0}")]
        public decimal Stock { get; set; }

        [DisplayName("Weight (Kg)")]
        public decimal Weight { get; set; }

        [DisplayName("Size (m³)")]
        public decimal Size { get; set; }

        public bool IsActivated { get; set; }

        [DisplayName("Created"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? Created { get; set; }
        
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        [DisplayName("Modified"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? Modified { get; set; }

        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }
    }
}
