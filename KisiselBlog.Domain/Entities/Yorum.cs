namespace KisiselBlog.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        public int YorumId { get; set; }

        [Column("Yorum")]
        [Required]
        [StringLength(1550)]
        public string Yorum1 { get; set; }

        public int MakaleID { get; set; }

        public DateTime? EklenmeTarihi { get; set; }

        [StringLength(150)]
        public string AdSoyad { get; set; }

        public int? Begeni { get; set; }

        public virtual Makale Makale { get; set; }
    }
}
