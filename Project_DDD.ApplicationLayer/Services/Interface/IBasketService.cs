using Project_DDD.ApplicationLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.ApplicationLayer.Services.Interface
{
   public interface IBasketService
    {
        Task<int> IdFromName(string name);
        Task<BasketDTO> GetById(int id);
        Task<BasketDTO> GetByUserProductId(int Userid, int productId);
        Task Edit(BasketDTO editDTO);
        Task Add(BasketDTO AddDTO);
        Task Delete(int id);
        Task<List<BasketDTO>> List(int pageIndex);
        Task<List<BasketDTO>> GetAll();
    }
}
