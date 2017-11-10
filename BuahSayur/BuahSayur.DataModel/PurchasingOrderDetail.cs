namespace BuahSayur.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchasingOrderDetail")]
    public partial class PurchasingOrderDetail
    {
        public int Id { get; set; }

        public int PurchasingOrder_Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Item_Code { get; set; }

        public decimal Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(10)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(10)]
        public string ModifiedBy { get; set; }

        public virtual Item Item { get; set; }

        public virtual PurchasingOrder PurchasingOrder { get; set; }
    }
}
