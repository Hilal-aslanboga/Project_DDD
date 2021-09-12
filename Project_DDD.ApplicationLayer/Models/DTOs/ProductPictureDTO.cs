using Microsoft.AspNetCore.Http;
using Project_DDD.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_DDD.ApplicationLayer.Models.DTOs
{
    public class ProductPictureDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}

