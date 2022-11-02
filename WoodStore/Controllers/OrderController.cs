using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodStore.DAL.Interfaces;
using WoodStore.Domain.ViewModel.Orders;
using WoodStore.Service.Interfaces;

namespace WoodStore.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrderAsync()
        {
            var response = await _orderService.GetAllOrders();
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var response = await _orderService.GetById(orderId);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var response = await _orderService.DeleteOrder(orderId);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return RedirectToAction("GetCars");
            }

            return RedirectToAction("Errors");
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _orderService.GetById(id);
            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return RedirectToAction("Errors");
        }

        [HttpPost]
        public async Task<IActionResult> Save(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                   await _orderService.CreateOrder(model);
                }
                else
                {
                    await _orderService.UpdateOrder(model.Id, model);
                }
            }

            return RedirectToAction("GetOrder");
        }
    }
}
