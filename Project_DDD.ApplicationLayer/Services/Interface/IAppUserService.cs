using Microsoft.AspNetCore.Identity;
using Project_DDD.ApplicationLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DDD.ApplicationLayer.Services.Interface
{
   public interface IAppUserService
    {
        Task LogOut();
        Task DeleteUser(params object[] parameters);
        Task<IdentityResult> Register(RegisterDTO registerDTO);
        Task<SignInResult> Login(LoginDTO loginDTO);
        Task<int> UserIdFromName(string userName);
        Task<EditProfileDTO> GetById(int id);
        Task EditUser(EditProfileDTO editProfileDTO);
        Task<List<SearchUserDTO>> SearchUser(string keyword, int pageIndex);

        Task<List<ListUserDTO>> ListUser(int pageIndex);
        Task<List<ListUserDTO>> WaitListUser(int pageIndex);
        Task<List<ListUserDTO>> GetAll();
    }
}
