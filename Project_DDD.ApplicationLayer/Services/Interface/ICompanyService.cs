using Project_DDD.ApplicationLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.ApplicationLayer.Services.Interface
{
    public interface ICompanyService
    {
        Task<int> CompanyIdFromName(string companyname);
        Task<CompaniesDTO> GetById(int id);
        Task EditCompany(CompaniesDTO editCompanyDTO);
        Task AddCompany(CompaniesDTO AddCompany);
        Task DeleteCompany(int id);
        Task<List<CompaniesDTO>> ListCompany(int pageIndex);
        Task<List<CompaniesDTO>> GetAll();
    }
}
