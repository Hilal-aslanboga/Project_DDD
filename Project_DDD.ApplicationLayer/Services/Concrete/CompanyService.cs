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
    public class CompanyService :ICompanyService
    {
        private ICompanyRepository _companyRepository;
        private IMapper _Mapper;
        public CompanyService(ICompanyRepository companyRepository, IMapper Mapper)
        {
            _companyRepository = companyRepository;
            _Mapper = Mapper;
        }

        public async Task AddCompany(CompaniesDTO AddCompany)
        {
            await _companyRepository.Add(_Mapper.Map<Companies>(AddCompany));
            await _companyRepository.Commit();
            await _companyRepository.DisposeAsync();

        }

        public async Task<int> CompanyIdFromName(string companyname)
        {
            return await _companyRepository.GetFilteredFirstOrDefault(selector: x => x.Id, expression: x => x.CompanyName == companyname);
        }

        public async Task DeleteCompany(int id)
        {
            var removecompany = await _companyRepository.GetById(id);
            _companyRepository.Delete(removecompany);
            await _companyRepository.Commit();
        }

        public async Task EditCompany(CompaniesDTO editCompanyDTO)
        {
            _companyRepository.Update(_Mapper.Map<Companies>(editCompanyDTO));
            await _companyRepository.Commit();
        }

        public async Task<List<CompaniesDTO>> GetAll()
        {
            return _Mapper.Map<List<CompaniesDTO>>(await _companyRepository.GetAll());
        }

        public async Task<CompaniesDTO> GetById(int id)
        {
            return _Mapper.Map<CompaniesDTO>(await _companyRepository.GetById(id));
        }

        public async Task<List<CompaniesDTO>> ListCompany(int pageIndex)
        {
            var company = await _companyRepository.GetFilteredList(
               selector: x => new CompaniesDTO
               {
                   Id = x.Id,
                   AccountingCode = x.AccountingCode,
                   Address = x.Address,
                   City = x.City,
                   CompanyName = x.CompanyName,
                   DeleteDate = x.DeleteDate,
                   Fax = x.Fax,
                   Phone1 = x.Phone1,
                   Phone2 = x.Phone2,
                   RiskLimit = x.RiskLimit,
                   State = x.State,
                   TaxAdress = x.TaxAdress,
                   TaxNumber = x.TaxNumber,
                   TotalBalance = x.TotalBalance,
                   TotalRiskLimit = x.TotalRiskLimit,
                   UpdateDate = x.UpdateDate,
                   PlasiyerCode = x.PlasiyerCode,
                   Status = x.Status
               },
               expression: null,
               include: null,
               pageIndex: pageIndex,
               pageSize: 10);

            return company;
        }

        Task<List<CompaniesDTO>> ICompanyService.ListCompany(int pageIndex)
        {
            throw new NotImplementedException();
        }
    }
}

