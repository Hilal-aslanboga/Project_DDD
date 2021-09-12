using Microsoft.AspNetCore.Identity;
using Project_DDD.DomainLayer.Entities.Interface;
using Project_DDD.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_DDD.DomainLayer.Entities.Concrete
{
    public class AppUsers : IdentityUser<int>, IBaseEntity
    {


        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public int PlasiyerCode { get; set; }
        public string ImagePath { get; set; } = "/images/user/default.jpg";
        public int? CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Companies Companies { get; set; }


        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
