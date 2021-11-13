using ODT.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ODT.Repository.Interfaces
{
    public class ProductRepository : IProductRepositoy
    {
        private readonly IBaseRepository baseRepository;
        public ProductRepository(IBaseRepository _baseRepository)
        {
            baseRepository = _baseRepository;
        }

        public async Task<List<ProductViewModel>> GetAllProductsDetails()
        {
            return await baseRepository.GetDataReaderList<ProductViewModel>("GetProductDetails");
        }

        public async Task<ProductViewModel> GetProductDetailById(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<long> InsertUpdateOrderDetail(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
