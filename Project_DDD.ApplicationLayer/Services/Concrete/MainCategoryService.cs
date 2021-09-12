using AutoMapper;
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
    public class MainCategoryService:IMainCategoryService
    {
        private IMainCategoryRepository _mainCategoryRepository;
        private IMapper _Mapper;
        public MainCategoryService(IMainCategoryRepository mainCategoryRepository, IMapper Mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _Mapper = Mapper;
        }
        public async Task Add(CategoryDTO AddDTO)
        {
            await _mainCategoryRepository.Add(_Mapper.Map<MainCategories>(AddDTO));
            await _mainCategoryRepository.Commit();
            await _mainCategoryRepository.DisposeAsync();
        }

        public async Task Delete(int id)
        {
            var remove = await _mainCategoryRepository.GetById(id);
            _mainCategoryRepository.Delete(remove);
            await _mainCategoryRepository.Commit();
        }

        public async Task Edit(CategoryDTO editDTO)
        {
            _mainCategoryRepository.Update(_Mapper.Map<MainCategories>(editDTO));
            await _mainCategoryRepository.Commit();
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            return _Mapper.Map<List<CategoryDTO>>(await _mainCategoryRepository.GetAll());
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            return _Mapper.Map<CategoryDTO>(await _mainCategoryRepository.GetById(id));
        }

        public async Task<int> IdFromName(string name)
        {
            return await _mainCategoryRepository.GetFilteredFirstOrDefault(selector: x => x.Id, expression: x => x.CategoyName == name);
        }

        public async Task<List<CategoryDTO>> List(int pageIndex)
        {
            var category = await _mainCategoryRepository.GetFilteredList(
               selector: x => new CategoryDTO
               {
                   Id = x.Id,
                   CategoyName = x.CategoyName,
                   DeleteDate = x.DeleteDate,
                   Description = x.Description,
                   ImagePath = x.ImagePath,
                   UpdateDate = x.UpdateDate,
                   Status = x.Status
               },
               expression: null,
               include: null,
               pageIndex: pageIndex,
               pageSize: 10);

            return category;
        }
    }
}

