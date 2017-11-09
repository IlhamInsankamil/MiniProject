using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuahSayur.ViewModel
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayName("Customer Name")]
        public string FullName
        {
            get { return (!string.IsNullOrEmpty(FirstName) ? FirstName + " " : "").ToString() + (!string.IsNullOrEmpty(LastName) ? LastName + " " : "").ToString(); }
        }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
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
