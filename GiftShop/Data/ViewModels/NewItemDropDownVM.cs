using GiftShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Data.viewModels
{
    public class NewItemDropDownVM
    {
        public NewItemDropDownVM()
        {
            Catagories = new List<Category>();
        }
        public List<Category> Catagories { get; set; }
    }
}
