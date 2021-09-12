using AutoMapper;
using Project_DDD.ApplicationLayer.Models.DTOs;
using Project_DDD.DomainLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.ApplicationLayer.AutoMapper
{
   public class ProjectProfile:Profile
    {
        public ProjectProfile()
        {
            CreateMap<AppUsers, RegisterDTO>().ReverseMap();
            CreateMap<AppUsers, LoginDTO>().ReverseMap();
            CreateMap<AppUsers, SearchUserDTO>().ReverseMap();
            CreateMap<AppUsers, EditProfileDTO>().ReverseMap();
            CreateMap<AppUsers, ListUserDTO>().ReverseMap();
            CreateMap<Companies, CompaniesDTO>().ReverseMap();
            CreateMap<Products, ProductDTO>().ReverseMap();
            CreateMap<Brands, BrandDTO>().ReverseMap();
            CreateMap<MainCategories, CategoryDTO>().ReverseMap();
            CreateMap<SubCategories, CategoryDTO>().ReverseMap();
            CreateMap<ProductPictures, ProductPictureDTO>().ReverseMap();
            CreateMap<Basket, BasketDTO>().ReverseMap();
            CreateMap<Orders, OrderDTO>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailDto>().ReverseMap();
        }
    }
}
