using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using ShoppingList.Models.Entities;
using ShoppingList.Models.ViewModels;

namespace ShoppingList.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsService service;

        public ProductsController(ProductsService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View(service.GetProductsForIndex());
        }

        [HttpPost]
        [Route("remove")]
        public IActionResult Remove(int? id)
        {
            Console.WriteLine("test fail");
            List<Contents> itemList = new List<Contents>();
            itemList.RemoveAll(o => o.Id == id);
            return RedirectToAction(nameof(Index));

        }


        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            service.ClearList();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View(service.GetProductsForCreate());
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(ProductsCreateVM viewmodel)
        {
            if (!ModelState.IsValid)
                return View(viewmodel);

            service.Create(viewmodel);

            if (viewmodel.SubmitInfo == "Done")
            {
                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction(nameof(Create));

        }
    }
}