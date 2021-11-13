using ODT.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODT.Repository.Interfaces
{
    public interface IUserRepositoy
    {
        Task<UserDetailsViewModel> GetUserDetailById(long Id);
        Task<List<UserDetailsViewModel>> GetAllUserDetails();
        Task<UserDetailsViewModel> GetUserDetailByAuthentication(long Id);
        Task<long> InsertUpdateUserDetail(long Id=0);
    }
}
