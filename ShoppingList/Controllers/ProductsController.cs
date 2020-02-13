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
        [Route("index/remove/{id}")]
        public IActionResult Remove(int id)
        {
                service.RemoveItem(id);

                return Ok();
            

            //service.GetProductsForIndex().RemoveAll(o => o.Id == id);
            //return RedirectToAction("Index");
            //return NoContent();
            
            //Contents contents = dbo.
            // .Include(i => i.ms_student)
            // .Include(i => i.ms_user)
            // .Where(i => i.ID == id)
            // .Single();

            //db.ms_person.Remove(ms_person);
            //db.SaveChanges();
            //return RedirectToAction("Index");

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