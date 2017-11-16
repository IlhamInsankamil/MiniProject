namespace BuahSayur.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReturnOrderDetail")]
    public partial class ReturnOrderDetail
    {
        public int Id { get; set; }

        public int Return_Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Item_Code { get; set; }

        public decimal ReturnAmount { get; set; }

        public decimal? Replacement { get; set; }

        public decimal? Shortage { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(10)]
        public string CeatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(10)]
        public string ModifiedBy { get; set; }

        public virtual Item Item { get; set; }

        public virtual ReturnOrder ReturnOrder { get; set; }
    }
}
