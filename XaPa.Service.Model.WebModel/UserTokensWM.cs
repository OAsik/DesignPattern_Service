using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XaPa.Service.Model.WebModel
{
    public class UserTokensWM
    {
        public int UserTokenID { get; set; }

        public int UserID { get; set; }

        public string UserToken { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}