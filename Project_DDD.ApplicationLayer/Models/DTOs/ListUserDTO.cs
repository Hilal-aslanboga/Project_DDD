using Project_DDD.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.ApplicationLayer.Models.DTOs
{
    public class ListUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get; set; }
        public int PlasiyerCode { get; set; }
        public int? CompanyId { get; set; }
        public CompaniesDTO Companies { get; set; }
        public Status Status { get; set; }

    }
}