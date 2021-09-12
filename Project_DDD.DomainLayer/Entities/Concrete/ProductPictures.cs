using Project_DDD.DomainLayer.Entities.Interface;
using Project_DDD.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Project_DDD.DomainLayer.Entities.Concrete
{
    public class ProductPictures : IBaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Products Products { get; set; }

        public string ImagePath { get; set; } = "/images/Product/default.jpg";

        [NotMapped]
        public IFormFile Image { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
