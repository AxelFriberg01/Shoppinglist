using System;
using System.Collections.Generic;

namespace ShoppingList.Models.Entities
{
    public partial class Contents
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string OptionalQuantityInfo { get; set; }
        public int StoreSection { get; set; }
    }
}
