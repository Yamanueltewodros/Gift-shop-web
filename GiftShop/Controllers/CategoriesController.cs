using GiftShop.Data;
using GiftShop.Data.Services;
using GiftShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _service;

        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        //Create new category
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CategoryName")] Category category)
        {
            if (!ModelState.IsValid) //Checks for requirements in the model
            {
                return View(category);
            }
            _service.Add(category);
            return RedirectToAction(nameof(Index));
        }

        //Update category
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDetail = await _service.GetById(id);
            if (categoryDetail == null) 
                return View("NotFound");


            return View(categoryDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, CategoryName")] Category category)
        {
            if (!ModelState.IsValid) //Checks for requirements in the model
            {
                return View(category);
            }
            await _service.Update(id, category);
            return RedirectToAction(nameof(Index));
        }

        //Delete category
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDetail = await _service.GetById(id);
            if (categoryDetail == null)
                return View("NotFound");


            return View(categoryDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryDetail = await _service.GetById(id);
            if (categoryDetail == null)
                return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
