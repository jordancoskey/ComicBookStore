namespace ComicBookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comic
    {
        public int ComicID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int Edition { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        public byte[] Cover { get; set; }

        public short Price { get; set; }
    }
}
