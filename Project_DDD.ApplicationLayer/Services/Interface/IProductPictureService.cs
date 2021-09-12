using Project_DDD.ApplicationLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.ApplicationLayer.Services.Interface
{
    public interface IProductPictureService
    {
        Task<int> IdFromName(string name);
        Task<ProductPictureDTO> GetById(int id);
        Task Edit(ProductPictureDTO editDTO);
        Task Add(ProductPictureDTO AddDTO);
        Task Delete(int id);

        Task<List<ProductPictureDTO>> GetAll();
    }
}
