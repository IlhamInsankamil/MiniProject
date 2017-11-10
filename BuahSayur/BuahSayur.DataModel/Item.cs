namespace BuahSayur.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        public Item()
        {
            DeliveryOrderDetails = new HashSet<DeliveryOrderDetail>();
            PurchasingOrderDetails = new HashSet<PurchasingOrderDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(1)]
        public string Category { get; set; }

        public decimal Stock { get; set; }

        public decimal Weight { get; set; }

        public decimal Size { get; set; }

        public bool IsActivated { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual ICollection<DeliveryOrderDetail> DeliveryOrderDetails { get; set; }

        public virtual ICollection<PurchasingOrderDetail> PurchasingOrderDetails { get; set; }
    }
}
