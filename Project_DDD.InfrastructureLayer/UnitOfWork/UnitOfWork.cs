using Project_DDD.DomainLayer.Repositories.Interface.EntityType;
using Project_DDD.DomainLayer.UnitOfWork;
using Project_DDD.InfrastructureLayer.Context;
using Project_DDD.InfrastructureLayer.Repositories.Concrete.EntityType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.InfrastructureLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        private IOrderRepository _orderRepository;
        public IOrderRepository OrderRepository => _orderRepository ?? (_orderRepository = new OrderRepository(_context));


        private IOrderDetailsRepository _orderDetailsRepository;
        public IOrderDetailsRepository OrderDetailsRepository => _orderDetailsRepository ?? (_orderDetailsRepository = new OrderDetailRepository(_context));

        private IBasketRepository _basketRepository;
        public IBasketRepository BasketRepository => _basketRepository ?? (_basketRepository = new BasketRepository(_context));

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository => _productRepository ?? (_productRepository = new ProductRepository(_context));

        private ICompanyRepository _companyRepository;
        public ICompanyRepository CompanyRepository => _companyRepository ?? (_companyRepository = new CompanyRepository(_context));

        private IAppUserRepository _appUserRepository;
        public IAppUserRepository AppUser => _appUserRepository ?? (_appUserRepository = new AppUserRepository(_context));

        public async Task Commit() => await _context.SaveChangesAsync();

        private bool isDispose = false;

        public async ValueTask DisposeAsync()
        {
            if (!isDispose)
            {
                isDispose = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);
                //Ortak dil çalışma zamanının belirtilen nesne için sonlandırıcıyı çağırmamasını ister.
            }
        }
        protected async ValueTask DisposeAsync(bool disposing)
        {
            if (disposing) await _context.DisposeAsync();
        }
    }
}
