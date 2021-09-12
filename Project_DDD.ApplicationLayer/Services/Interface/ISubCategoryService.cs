using Project_DDD.ApplicationLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.ApplicationLayer.Services.Interface
{
    public interface ISubCategoryService
    {
        Task<int> IdFromName(string name);
        Task<CategoryDTO> GetById(int id);
        Task Edit(CategoryDTO editDTO);
        Task Add(CategoryDTO AddDTO);
        Task Delete(int id);
        Task<List<CategoryDTO>> List(int pageIndex);
        Task<List<CategoryDTO>> GetAll();
    }
}
