using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

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
    public IActionResult GetAllCategories()
    {
        var categories = _categoryService.GetAllCategories();
        
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        var category = _categoryService.GetCategoryById(id);
        
        return Ok(category);
    }

    [HttpPost]
    public IActionResult CreateCategory(CreateUpdateCategoryDto createCategory)
    {
        var category = _categoryService.AddNewCategory(createCategory);
        
        return Created($"api/category/{category.Id}", category);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, CreateUpdateCategoryDto updateCategory)
    {
        var categoryToUpdate = _categoryService.GetCategoryById(id);
        _categoryService.UpdateCategory(categoryToUpdate.Id, updateCategory);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        _categoryService.DeleteCategory(id);
        return NoContent();
    }
}