namespace XaPa.Service.Model.Entity.XaPa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserTokens
    {
        [Key]
        public int UserTokenID { get; set; }

        public int UserID { get; set; }

        [Required]
        public string UserToken { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public virtual Users Users { get; set; }
    }
}
