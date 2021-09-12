using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_DDD.ApplicationLayer.Models.DTOs;
using Project_DDD.ApplicationLayer.Services.Interface;
using Project_DDD.DomainLayer.Entities.Concrete;
using Project_DDD.DomainLayer.Repositories.Interface.EntityType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.ApplicationLayer.Services.Concrete
{
   public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _Mapper;
        public ProductService(IProductRepository productRepository, IMapper Mapper)
        {
            _productRepository = productRepository;
            _Mapper = Mapper;
        }
        public async Task Add(ProductDTO AddCompany)
        {
            await _productRepository.Add(_Mapper.Map<Products>(AddCompany));
            await _productRepository.Commit();

        }

        public async Task Delete(int id)
        {
            var removeproduct = await _productRepository.GetById(id);
            _productRepository.Delete(removeproduct);
            await _productRepository.Commit();
        }

        public async Task Edit(ProductDTO editCompanyDTO)
        {
            _productRepository.Update(_Mapper.Map<Products>(editCompanyDTO));
            await _productRepository.Commit();
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            return _Mapper.Map<List<ProductDTO>>(await _productRepository.GetAll());
        }

        public async Task<ProductDTO> GetById(int id)
        {
            return _Mapper.Map<ProductDTO>(await _productRepository.GetById(id));
        }

        public async Task<List<ProductDTO>> List(int pageIndex)
        {
            var product = await _productRepository.GetFilteredList(
               selector: x => new ProductDTO
               {
                   Id = x.Id,
                   BrandId = x.BrandId,
                   ProductName = x.ProductName,
                   CriticalQuantity = x.CriticalQuantity,
                   CurrencyId = x.CurrencyId,
                   Description = x.Description,
                   ListPrice = x.ListPrice,
                   ListPriceVat = x.ListPriceVat,
                   MainCategoryId = x.MainCategoryId,
                   MaxSellerQuantity = x.MaxSellerQuantity,
                   ProductCode = x.ProductCode,
                   Quantity = x.Quantity,
                   SubCategoryId = x.SubCategoryId,
                   Vat = x.Vat,
                   ProductPictures = _Mapper.Map<ProductPictureDTO>(x.ProductPictures),
                   Brands = _Mapper.Map<BrandDTO>(x.Brands),
                   MainCategories = _Mapper.Map<CategoryDTO>(x.MainCategories),
                   Status = x.Status,
                   SubCategories = _Mapper.Map<CategoryDTO>(x.SubCategories)

               },
               expression: null,
               include: x => x.Include(a => a.MainCategories).Include(z => z.ProductPictures).Include(s => s.SubCategories).Include(k => k.Brands),
               pageIndex: pageIndex,
               pageSize: 10);

            return product;
        }

        public async Task<int> ProductIdFromName(string productname)
        {
            return await _productRepository.GetFilteredFirstOrDefault(selector: x => x.Id, expression: x => x.ProductName == productname);
        }

        Task<List<ProductDTO>> IProductService.List(int pageIndex)
        {
            throw new NotImplementedException();
        }
    }
}

