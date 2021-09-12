using Project_DDD.DomainLayer.Entities.Interface;
using Project_DDD.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.DomainLayer.Entities.Concrete
{
    public class Orders : IBaseEntity
    {
        public Guid Id { get; set; }
        public int AppUserId { get; set; }
        public AppUsers AppUsers { get; set; }
        public int CompanyId { get; set; }
        public Companies Companies { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalTax { get; set; }


        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
