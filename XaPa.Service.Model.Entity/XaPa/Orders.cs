namespace XaPa.Service.Model.Entity.XaPa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [Key]
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual OrderDetails OrderDetails { get; set; }

        public virtual Users Users { get; set; }
    }
}
