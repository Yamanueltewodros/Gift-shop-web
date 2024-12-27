using GiftShop.Data.Base;
using GiftShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Data.Services
{
    public interface ICategoriesService : IEntityBaseRepository<Category>
    {
    }
}
