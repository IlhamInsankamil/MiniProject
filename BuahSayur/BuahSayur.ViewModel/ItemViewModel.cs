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

        [RegularExpression(@"[A-Z0-9]{7}$", ErrorMessage = "Code must be 7 characters. Contains Number and Letters(in Capitol).")]
        public string Code { get; set; }

        [RegularExpression(@"[A-Za-z\s]{0,}", ErrorMessage = "Item name should only Letters.")]
        public string Name { get; set; }

        [DisplayName("Selling Price (/pack)")]
        [RegularExpression("[0-9]{0,}", ErrorMessage = "Must be a number and not minus.")]
        public decimal Price_Selling { get; set; }

        [DisplayName("Purchasing Price (/pack)")]
        [RegularExpression("[0-9]{0,}", ErrorMessage = "Must be a number and not minus.")]
        public decimal Price_Purchasing { get; set; }

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
        [RegularExpression("[0-9]{0,}", ErrorMessage = "Must be a number and not minus.")]
        public decimal Stock { get; set; }

        [DisplayName("Weight (Kg)"), DisplayFormat(DataFormatString = "{0:0.0}")]
        [RegularExpression("[0-9.]{0,}", ErrorMessage = "Must be a number and not minus.")]
        public decimal Weight { get; set; }

        [DisplayName("Size (m³)"), DisplayFormat(DataFormatString = "{0:0.00}")]
        [RegularExpression("[0-9.]{0,}", ErrorMessage = "Must be a number and not minus.")]
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

        //public static List<WeightReference> GetWeightList(){
        //    List<WeightReference> result = new List<WeightReference>
        //    {
        //        new WeightReference {Value = 0.5, Display = "0.5"},
        //        new WeightReference {Value = 1, Display = "1"},
        //        new WeightReference {Value = 5, Display = "5"},
        //        new WeightReference {Value = 10, Display = "10"}
        //    };
        //    return result;
        //}
    }

    //public class WeightReference{
    //    public double Value { get; set; }
    //    public string Display { get; set; }
    //}
}
