using Autofac;
using FluentValidation;
using Project_DDD.ApplicationLayer.Models.DTOs;
using Project_DDD.ApplicationLayer.Services.Concrete;
using Project_DDD.ApplicationLayer.Services.Interface;
using Project_DDD.ApplicationLayer.Validations.FluentValidations;
using Project_DDD.DomainLayer.Repositories.Interface.EntityType;
using Project_DDD.DomainLayer.UnitOfWork;
using Project_DDD.InfrastructureLayer.Repositories.Concrete.EntityType;
using Project_DDD.InfrastructureLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Module = Autofac.Module;

namespace Project_DDD.ApplicationLayer.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Serivces
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<BrandService>().As<IBrandService>().InstancePerLifetimeScope();
            builder.RegisterType<MainCategoryService>().As<IMainCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<SubCategoryService>().As<ISubCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductPictureService>().As<IProductPictureService>().InstancePerLifetimeScope();
            builder.RegisterType<BasketService>().As<IBasketService>().InstancePerLifetimeScope();
            //UnitofWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            //Repository
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BrandRepository>().As<IBrandRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MainCategoryRepository>().As<IMainCategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SubCategoryRepository>().As<ISubCategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductPictureRepository>().As<IProductPictureRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BasketRepository>().As<IBasketRepository>().InstancePerLifetimeScope();
            //Validation
            builder.RegisterType<LoginValidation>().As<IValidator<LoginDTO>>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterValidation>().As<IValidator<RegisterDTO>>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}