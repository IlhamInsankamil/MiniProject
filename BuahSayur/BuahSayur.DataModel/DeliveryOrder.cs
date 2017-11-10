namespace BuahSayur.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeliveryOrder")]
    public partial class DeliveryOrder
    {
        public DeliveryOrder()
        {
            DeliveryOrderDetails = new HashSet<DeliveryOrderDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Number { get; set; }

        public int Customer_Id { get; set; }

        public DateTime SellingDate { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(10)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(10)]
        public string ModifiedBy { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<DeliveryOrderDetail> DeliveryOrderDetails { get; set; }
    }
}
