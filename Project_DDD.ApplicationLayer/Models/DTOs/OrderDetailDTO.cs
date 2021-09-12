using Project_DDD.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.ApplicationLayer.Models.DTOs
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }


        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

    }
}