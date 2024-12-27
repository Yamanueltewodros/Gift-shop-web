using GiftShop.Data.Base;
using GiftShop.Data.viewModels;
using GiftShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Data.Services
{
    public class ItemsService : EntityBaseRepository<Item>, IItemsService
    {

        private readonly AppDbContext _context;
        public ItemsService(AppDbContext context) : base (context)
        {
            _context = context;
        }

        public async Task<Item> GetItemById(int id)
        {
            var itemDetail = await _context.Items.Include(c => c.Category).FirstOrDefaultAsync(n => n.Id == id);
            return itemDetail;
        }

        public async Task<NewItemDropDownVM> GetNewItemDropDownValues()
        {
            var response = new NewItemDropDownVM();
            response.Catagories = await _context.Categories.OrderBy(n => n.CategoryName).ToListAsync();
            return response;
        }

        /*
        public void Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Items.FirstOrDefaultAsync(n => n.Id == id);
            _context.Items.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            var result = await _context.Items.Include(c => c.Category).ToListAsync();
            return result;
        }

        public async Task<Item> GetById(int id)
        {
            var result = await _context.Items.Include(c => c.Category).FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public Item Update(int id, Item newItem)
        {
            _context.Update(newItem);
            _context.SaveChanges();
            return newItem;
        }
        */
    }
}
