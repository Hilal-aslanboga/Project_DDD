using Project_DDD.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.DomainLayer.Entities.Interface
{
    public interface IBaseEntity
    {
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
        DateTime? DeleteDate { get; set; }
        Status Status { get; set; }
    }
}
