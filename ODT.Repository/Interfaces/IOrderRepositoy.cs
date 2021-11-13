using ODT.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODT.Repository.Interfaces
{
    public interface IOrderRepositoy
    {
        Task<OrderViewModel> GetOrderDetailById(long Id);
        Task<List<OrderViewModel>> GetAllOrderDetails(string searchKey, int take, int skip);
        Task<long> InsertUpdateOrderDetail(OrderViewModel orderViewModel);
    }
}
