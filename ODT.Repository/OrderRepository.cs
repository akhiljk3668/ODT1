using ODT.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ODT.Repository.Interfaces
{
    public class OrderRepository : IOrderRepositoy
    {
        private readonly IBaseRepository baseRepository;
        public OrderRepository(IBaseRepository _baseRepository)
        {

            baseRepository = _baseRepository;
        }

        public async Task<List<OrderViewModel>> GetAllOrderDetails(string searchKey, int take, int skip)
        {
            List<SqlParameter> listSqlParameter = new List<SqlParameter>();
            if(!string.IsNullOrEmpty(searchKey))
                 baseRepository.AddParameter("searchKey", take, ref listSqlParameter);
            baseRepository.AddParameter("Take", take, ref listSqlParameter);
            baseRepository.AddParameter("Skip", skip, ref listSqlParameter);
            return await baseRepository.GetDataReaderList<OrderViewModel>("GetOrderDetails", listSqlParameter);
        }

        public async Task<OrderViewModel> GetOrderDetailById(long Id)
        {
            List<SqlParameter> listSqlParameter = new List<SqlParameter>();
            baseRepository.AddParameter("OrderId", Id, ref listSqlParameter);
            return await baseRepository.GetDataReader<OrderViewModel>("GetOrderDetails",listSqlParameter);
        }

        public async Task<long> InsertUpdateOrderDetail(OrderViewModel orderViewModel)
        {
            List<SqlParameter> listSqlParameter = new List<SqlParameter>();
            if (orderViewModel.OrderId > 0)
                baseRepository.AddParameter("OrderId", orderViewModel.OrderId, ref listSqlParameter);
            baseRepository.AddParameter("Description", orderViewModel.Description, ref listSqlParameter);
            baseRepository.AddParameter("IsActive", orderViewModel.IsActive, ref listSqlParameter);
            baseRepository.AddParameter("UserId", orderViewModel.UserId, ref listSqlParameter);
            return (await baseRepository.GetDataReader<OrderViewModel>("InsertUpdateOrderDetails", listSqlParameter)).OrderId;

        }
    }
}
