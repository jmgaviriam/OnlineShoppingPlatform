﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.DTO
{
    public class UpdatePayment
    {
        public string PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public string CVV { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
