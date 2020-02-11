using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models.ViewModels
{
    public class ProductsCreateVM
    {
        [Display(Name = "Name of product")]
        [Required(ErrorMessage = "Enter a product name")]
        public string ProductName { get; set; }

        [Display(Name = "Quantity info (optional)")]
        public string OptionalQuantityInfo { get; set; }

        [Display(Name = "Section in store")]
        //[Required(ErrorMessage = "Enter in which section of the store the above product can be located")]
        public SelectListItem[] StoreSection { get; set; }

        [Range(1, 10)]
        public int SelectedStoreSection { get; set; }

        public string SubmitInfo { get; set; }



    }

    
}
