using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingList.Models.Entities;
using ShoppingList.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class ProductsService
    {

        private readonly ShoppingCartContext context;

        public ProductsService(ShoppingCartContext context)
        {
            this.context = context;
        }

        //static int id = 1;

        //internal void RemoveRow()
        //{
        //    context.Contents.RemoveRange(context.Contents);

        //    context.SaveChanges();
        //}
       
        internal void ClearList()
        {
            context.Contents.RemoveRange(context.Contents);

            context.SaveChanges();
        }


        //static List<Product> shoppingList = new List<Product>
        //{
        //    new Product {Id = id++, ProductName = "Banan", OptionalQuantityInfo = "1 klase", StoreSection = 1},
        //    new Product {Id = id++, ProductName = "Äpplen", OptionalQuantityInfo = "ca 1 kg", StoreSection = 1},
        //    new Product {Id = id++, ProductName = "Havregryn", OptionalQuantityInfo = "", StoreSection = 6},
        //    new Product {Id = id++, ProductName = "Ägg", OptionalQuantityInfo = "6 ägg", StoreSection = 2},
        //    new Product {Id = id++, ProductName = "Mjölk", OptionalQuantityInfo = "", StoreSection = 3},
        //    new Product {Id = id++, ProductName = "Apelsinjuice", OptionalQuantityInfo = "", StoreSection = 3},
        //    new Product {Id = id++, ProductName = "Choklad", OptionalQuantityInfo = "Lindt 55%", StoreSection = 9},
        //    new Product {Id = id++, ProductName = "Blåbär", OptionalQuantityInfo = "Frysta", StoreSection = 8},
        //    new Product {Id = id++, ProductName = "Ost", OptionalQuantityInfo = "Grana Padano", StoreSection = 5},
        //    new Product {Id = id++, ProductName = "Kyckling", OptionalQuantityInfo = "Hel kyckling", StoreSection = 5},
        //};

        internal ProductsCreateVM GetProductsForCreate()
        {
            var viewModel = new ProductsCreateVM
            {
                StoreSection = new SelectListItem[]
                {
                    new SelectListItem { Value = "1", Text = "1. Fruits & Veggies", Selected = true},
                    new SelectListItem { Value = "2", Text = "2. Bread, Cookies, Coffee, Tee"},
                    new SelectListItem { Value = "3", Text = "3. Dairy & Juice"},
                    new SelectListItem { Value = "4", Text = "4. Frozen foods"},
                    new SelectListItem { Value = "5", Text = "5. Meat & Cheese"},
                    new SelectListItem { Value = "6", Text = "6. Dry goods & Canned food"},
                    new SelectListItem { Value = "7", Text = "7. Toiletries"},
                    new SelectListItem { Value = "8", Text = "8. Nuts, Berries, Ice Cream"},
                    new SelectListItem { Value = "9", Text = "9. Candy & Magazines"},
                }
            };
            return viewModel;
        }


        public ProductsIndexVM[] GetProductsForIndex()
        {
         
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("sv-SE");

            return context.Contents
                .OrderBy(o => o.StoreSection)
                .ThenBy(o => o.ProductName)
                .Select(o => new ProductsIndexVM
                {
                    ProductName = o.ProductName,
                    OptionalQuantityInfo = o.OptionalQuantityInfo,
                })
            .ToArray();
        }

        internal void Create(ProductsCreateVM viewmodel)
        {
            // Convert viewmodel to db model
            context.Contents.Add(new Contents
            {
                ProductName = viewmodel.ProductName,
                OptionalQuantityInfo = viewmodel.OptionalQuantityInfo,
                StoreSection = viewmodel.SelectedStoreSection,
            });

            context.SaveChanges();
        }

    }
}
