using Microsoft.AspNetCore.Mvc;
using OrderProcessingApp.Models;

namespace OrderProcessingApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index() => View(new Order());

        [HttpPost]
        public IActionResult ProcessOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", order);
            }


            return View("Result", order);
        }
    }
}
