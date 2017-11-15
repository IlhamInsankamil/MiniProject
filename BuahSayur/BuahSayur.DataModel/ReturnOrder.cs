namespace BuahSayur.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReturnOrder")]
    public partial class ReturnOrder
    {
        public ReturnOrder()
        {
            ReturnOrderDetails = new HashSet<ReturnOrderDetail>();
        }

        public int Id { get; set; }

        public int DeliveryOrder_Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Reference { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(10)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(10)]
        public string ModifiedBy { get; set; }

        public virtual DeliveryOrder DeliveryOrder { get; set; }

        public virtual ICollection<ReturnOrderDetail> ReturnOrderDetails { get; set; }
    }
}
