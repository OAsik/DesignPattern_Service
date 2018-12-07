namespace XaPa.Service.Model.Entity.XaPa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductImages
    {
        [Key]
        public int ProductImageID { get; set; }

        [Column(TypeName = "image")]
        public byte[] ProductPicture { get; set; }

        public virtual Products Products { get; set; }
    }
}
