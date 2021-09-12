using Project_DDD.DomainLayer.Entities.Concrete;
using Project_DDD.DomainLayer.Repositories.Interface.EntityType;
using Project_DDD.InfrastructureLayer.Context;
using Project_DDD.InfrastructureLayer.Repositories.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.InfrastructureLayer.Repositories.Concrete.EntityType
{
    public class OrderRepository:BaseRepository<Orders>,IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
