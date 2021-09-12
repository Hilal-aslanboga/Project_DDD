using Project_DDD.DomainLayer.Repositories.Interface.EntityType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.DomainLayer.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAppUserRepository AppUser { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IBasketRepository BasketRepository { get; }
        IProductRepository ProductRepository { get; }
        ICompanyRepository CompanyRepository { get; }

        Task Commit();
    }
}
