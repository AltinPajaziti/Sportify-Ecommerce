﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.DTOs
{
    public class OdersDto
    {
        public string ProductName { get; set; }

        public string ClientName { get; set; }
       // public string ClientAddress { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }
}
