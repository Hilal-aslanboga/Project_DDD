﻿using Project_DDD.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.ApplicationLayer.Models.DTOs
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public EditProfileDTO AppUsers { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Products { get; set; }
        public int BasketQuantity { get; set; }


        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}
