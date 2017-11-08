using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class CityViewModel
    {
        public int Id { get; set; }

        
        public string Code { get; set; }

        
        public string Province_Code { get; set; }

        public string ProvinceName { get; set; }
        
        public string Name { get; set; }
        
        public string PostalCode { get; set; }
        public DateTime? Created { get; set; }
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }
        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }
    }
}
