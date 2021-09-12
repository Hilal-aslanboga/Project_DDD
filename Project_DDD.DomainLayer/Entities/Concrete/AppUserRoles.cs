using Microsoft.AspNetCore.Identity;
using Project_DDD.DomainLayer.Entities.Interface;
using Project_DDD.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.DomainLayer.Entities.Concrete
{
    public class AppUserRoles : IdentityRole<int>, IBaseEntity
    {
        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set ; }
        public DateTime? DeleteDate { get; set ; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
