using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.ApplicationLayer.Models.DTOs
{
    public class SearchUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get; set; }
    }
}
