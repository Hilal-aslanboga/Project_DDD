using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_DDD.ApplicationLayer.Models.DTOs;
using Project_DDD.ApplicationLayer.Services.Interface;
using Project_DDD.DomainLayer.Entities.Concrete;
using Project_DDD.DomainLayer.Repositories.Interface.EntityType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.ApplicationLayer.Services.Concrete
{
    public class BasketService : IBasketService
    {

        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _Mapper;
        public BasketService(IBasketRepository basketRepository, IMapper Mapper)
        {
            _basketRepository = basketRepository;
            _Mapper = Mapper;
        }
        public async Task Add(BasketDTO AddDTO)
        {
            await _basketRepository.Add(_Mapper.Map<Basket>(AddDTO));
            await _basketRepository.Commit();
            await _basketRepository.DisposeAsync();
        }

        public async Task Delete(int id)
        {
            var removeproduct = await _basketRepository.GetById(id);
            _basketRepository.Delete(removeproduct);
            await _basketRepository.Commit();
        }

        public async Task Edit(BasketDTO editDTO)
        {
            _basketRepository.Update(_Mapper.Map<Basket>(editDTO));
            await _basketRepository.Commit();
        }

        public async Task<List<BasketDTO>> GetAll()
        {
            return _Mapper.Map<List<BasketDTO>>(await _basketRepository.GetAll());
        }

        public async Task<BasketDTO> GetById(int id)
        {
            return _Mapper.Map<BasketDTO>(await _basketRepository.GetById(id));
        }

        public async Task<BasketDTO> GetByUserProductId(int Userid, int productId)
        {
            return _Mapper.Map<BasketDTO>(_basketRepository.Get(x => x.AppUserId == Userid && x.ProductId == productId).Result.FirstOrDefault());
        }

        public Task<int> IdFromName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BasketDTO>> List(int pageIndex)
        {
            var product = await _basketRepository.GetFilteredList(
               selector: x => new BasketDTO
               {
                   Id = x.Id,
                   AppUserId = x.AppUserId,
                   AppUsers = _Mapper.Map<EditProfileDTO>(x.AppUsers),
                   BasketQuantity = x.BasketQuantity,
                   DeleteDate = x.DeleteDate,
                   ProductId = x.ProductId,
                   Products = _Mapper.Map<ProductDTO>(x.Products),
                   Status = x.Status,
                   UpdateDate = x.UpdateDate
               },
               expression: null,
               include: x => x.Include(z => z.AppUsers).Include(z => z.Products).ThenInclude(a => a.Brands).Include(p => p.Products).ThenInclude(s => s.ProductPictures),
               pageIndex: pageIndex,
               orderBy: x => x.OrderBy(z => z.Id),
               pageSize: 10);

            return product;
        }
    }
}

