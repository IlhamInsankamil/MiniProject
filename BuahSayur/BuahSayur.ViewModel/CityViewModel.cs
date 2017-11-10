using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class CityViewModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^[0-9A-Za-z]{0,6}$", ErrorMessage = "Please enter only number up to 12 digits")]        
        public string Code { get; set; }

        public string Province_Code { get; set; }

        public string ProvinceName { get; set; }
        
        public string Name { get; set; }
        
        public string PostalCode { get; set; }

        public bool IsActivated { get; set; }

        public DateTime? Created { get; set; }
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }
        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }
    }
}
