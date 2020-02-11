using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models.ViewModels
{
    public class ProductsIndexVM
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Info")]
        public string OptionalQuantityInfo { get; set; }

        public bool DropList { get; set; }

    }
}
