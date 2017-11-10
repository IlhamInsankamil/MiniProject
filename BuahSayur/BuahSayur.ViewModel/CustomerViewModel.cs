using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DisplayName("Phone Number")]
        [RegularExpression(@"^\d[0-9]{9,12}$", ErrorMessage = "Please enter only number up to 12 digits")]
        public string PhoneNumber { get; set; }

        [DisplayName("Province")]
        public string Province_Code { get; set; }

        [DisplayName("Province")]
        public string Province_Name { get; set; }

        [DisplayName("City")]
        public string City_Code { get; set; }

        [DisplayName("City")]
        public string City_Name { get; set; }

        [DisplayName("Address")]
        public string FullAddress // not in create
        {
            get
            {
                return (!string.IsNullOrEmpty(Address) ? Address + ", " : "").ToString()
                    + (!string.IsNullOrEmpty(City_Name) ? City_Name + ", " : "").ToString()
                    + (!string.IsNullOrEmpty(Province_Name) ? Province_Name + " " : "").ToString();
            }
        }

        public bool IsActivated { get; set; }

        public DateTime? Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public string ModifiedBy { get; set; }
    }
}
