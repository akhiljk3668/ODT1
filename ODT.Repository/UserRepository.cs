using ODT.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ODT.Repository.Interfaces
{
    public class UserRepository : IUserRepositoy
    {
        private readonly IBaseRepository baseRepository;
        public UserRepository(IBaseRepository _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public async Task<UserDetailsViewModel> GetUserDetailById(long Id)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            baseRepository.AddParameter("UserId", Id,ref sqlParameters);
            return await baseRepository.GetDataReader<UserDetailsViewModel>("GetUserDetails", sqlParameters);
        }
        public async Task<List<UserDetailsViewModel>> GetAllUserDetails()
        {
            return await baseRepository.GetDataReaderList<UserDetailsViewModel>("GetUserDetails");
        }

        public Task<UserDetailsViewModel> GetUserDetailByAuthentication(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<long> InsertUpdateUserDetail(long Id = 0)
        {
            throw new NotImplementedException();
        }
    }
}
