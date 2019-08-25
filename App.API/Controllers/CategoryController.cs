using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.API.ViewModels;
using App.Model;
using App.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetCategories();
            var categoriesViewModel = new List<CategoryViewModel>();
            Mapper.Map(categories, categoriesViewModel);
            return Ok(categoriesViewModel);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var category = await _categoryService.GetCategoryById(new ObjectId(id));
            if (category == null)
                return NotFound();

            var categoryViewModel = new CategoryViewModel();
            Mapper.Map(category, categoryViewModel);
            return Ok(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryViewModel categoryVM)
        {
            var category = new Category();
            Mapper.Map(categoryVM, category);
            await _categoryService.AddCategory(category);
            Mapper.Map(category, categoryVM);
            return Created(Url.Link("Default", new { controller = "Category", id = category.Id.ToString() }), category);

        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, [FromBody]CategoryViewModel categoryVM)
        {
            var category = await _categoryService.GetCategoryById(new ObjectId(id));
            if (category == null)
                return NotFound();

            Mapper.Map(categoryVM, category);
            await _categoryService.UpdateCategory(category);
            return Ok(categoryVM);
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _categoryService.GetCategoryById(new ObjectId(id));
            if (product == null)
                return NotFound();

            await _categoryService.DeleteCategory(new ObjectId(id));
            return Ok();
        }

    }
}