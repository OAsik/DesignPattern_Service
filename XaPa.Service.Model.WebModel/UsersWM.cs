using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XaPa.Service.Model.WebModel
{
    public class UsersWM
    {
        public int UserID { get; set; }

        public string UserNameSurname { get; set; }

        public int UserTitle { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string UserAppName { get; set; }

        public string UserPassword { get; set; }
    }
}