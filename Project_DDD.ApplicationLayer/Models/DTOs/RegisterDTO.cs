using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.ApplicationLayer.Models.DTOs
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string ImagePath => "/images/users/defaults.jpg";
    }
}
