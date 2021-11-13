using Microsoft.AspNetCore.Mvc;
using ODT.Data.ViewModels;
using ODT.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODT.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepositoy orderRepositoy;
        private readonly IProductRepositoy productRepositoy;
        public OrderController(IOrderRepositoy _orderRepositoy,IProductRepositoy _productRepositoy)
        {
            orderRepositoy = _orderRepositoy;
            productRepositoy = _productRepositoy;
        }
        [Route("Orders")]
        public async Task<IActionResult> Index()
        {
            return View(await orderRepositoy.GetAllOrderDetails(string.Empty,10,1));
        }
        [HttpGet]
        [Route("ManageOrder")]
        public async Task<IActionResult> Manage(long id = 0)
        {
            OrderViewModel orderViewModel;
            if (id > 0)
                orderViewModel = await orderRepositoy.GetOrderDetailById(id);
            else
                orderViewModel = new OrderViewModel();
            return View(orderViewModel);
        }
        [HttpPost]
        [Route("Order/Save")]
        public async Task<IActionResult> Manage(OrderViewModel orderViewModel)
        {
            orderViewModel.UserId = 5;
            orderViewModel.OrderId = await orderRepositoy.InsertUpdateOrderDetail(orderViewModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
