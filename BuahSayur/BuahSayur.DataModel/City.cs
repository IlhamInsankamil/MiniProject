namespace BuahSayur.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {
        public City()
        {
            Customers = new HashSet<Customer>();
            Suppliers = new HashSet<Supplier>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(10)]
        public string Province_Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; }

        public bool IsActivated { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Province Province { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
