namespace BuahSayur.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShipmentOrder")]
    public partial class ShipmentOrder
    {
        public int Id { get; set; }

        public int DeliveryOrder_Id { get; set; }

        public DateTime ShippingDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Vehicle { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonInCharge { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(10)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(10)]
        public string ModifiedBy { get; set; }

        public virtual DeliveryOrder DeliveryOrder { get; set; }
    }
}
