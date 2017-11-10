namespace BuahSayur.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchasingOrder")]
    public partial class PurchasingOrder
    {
        public PurchasingOrder()
        {
            PurchasingOrderDetails = new HashSet<PurchasingOrderDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Supplier_Code { get; set; }

        public DateTime PurchasingDate { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(10)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(10)]
        public string ModifiedBy { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<PurchasingOrderDetail> PurchasingOrderDetails { get; set; }
    }
}
