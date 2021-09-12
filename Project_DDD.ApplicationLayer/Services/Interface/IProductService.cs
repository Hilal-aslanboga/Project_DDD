using Project_DDD.ApplicationLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.ApplicationLayer.Services.Interface
{
    public interface IProductService
    {
        Task<int> ProductIdFromName(string productname);
        Task<ProductDTO> GetById(int id);
        Task Edit(ProductDTO editCompanyDTO);
        Task Add(ProductDTO AddCompany);
        Task Delete(int id);
        Task<List<ProductDTO>> List(int pageIndex);
        Task<List<ProductDTO>> GetAll();
    }
}
