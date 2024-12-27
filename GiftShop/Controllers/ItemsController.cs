using GiftShop.Data;
using GiftShop.Data.Services;
using GiftShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsService _service;
        public ItemsController(IItemsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll(n => n.Category);
            var itemDropDownData = await _service.GetNewItemDropDownValues();

            ViewBag.Categories = new SelectList(itemDropDownData.Catagories, "Id", "CategoryName");
            return View(data);
        }

        //Filter
        public async Task<IActionResult> Filter(int categoryId)
        {
            var data = await _service.GetAll(n => n.Category);
            var itemDropDownData = await _service.GetNewItemDropDownValues();

            ViewBag.Categories = new SelectList(itemDropDownData.Catagories, "Id", "CategoryName");

            if (categoryId != 0)
            {
                var filterData = data.Where(n => n.CategoryId.Equals(categoryId)).ToList();
                return View("Index", filterData);
            }
            else
            {
                return View("Index", data.ToList());
            }
        }

        //Create new category
        public async Task<IActionResult> Create()
        {
            var itemDropDownData = await _service.GetNewItemDropDownValues();

            ViewBag.Categories = new SelectList(itemDropDownData.Catagories, "Id", "CategoryName"); //import MVC.Rendering library
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (!ModelState.IsValid) //Checks for requirements in the model
            {
                return View(item);
            }
            _service.Add(item);
            return RedirectToAction(nameof(Index));
        }

        //Details
        public async Task<IActionResult> Details (int id)
        {
            var details = await _service.GetItemById(id);

            if (details == null)
                return View("NotFound");
            else
                return View(details);
        }

        //Delete Item
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _service.GetById(id);
            if (item == null)
                return View("NotFound");


            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _service.GetById(id);
            if (item == null)
                return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //Update Items
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _service.GetById(id);
            if (item == null)
                return View("NotFound");


            var itemDropDownData = await _service.GetNewItemDropDownValues();
            ViewBag.Categories = new SelectList(itemDropDownData.Catagories, "Id", "CategoryName");
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ItemName, ImageURL, Price, AvailabilityStatus, Description, CategoryId")] Item item)
        {
            if (!ModelState.IsValid) //Checks for requirements in the model
            {
                return View(item);
            }
            await _service.Update(id, item);
            return RedirectToAction(nameof(Index));
        }
    }
}
