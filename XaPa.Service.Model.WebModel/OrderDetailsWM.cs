﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XaPa.Service.Model.WebModel
{
    public class OrderDetailsWM
    {
        public int OrderDetailID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }
    }
}