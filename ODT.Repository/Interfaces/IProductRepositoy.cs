using ODT.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODT.Repository.Interfaces
{
    public interface IProductRepositoy
    {
        Task<ProductViewModel> GetProductDetailById(long Id);
        Task<List<ProductViewModel>> GetAllProductsDetails();
        Task<long> InsertUpdateOrderDetail(ProductViewModel productViewModel);
    }
}
