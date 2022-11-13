using Application.Dto;

namespace Application.Interfaces;

public interface ICategoryService
{
    List<CategoryDto> GetAllCategories();
    CategoryDto GetCategoryById(int id);
    CategoryDto AddNewCategory(CreateUpdateCategoryDto newCategory);
    void UpdateCategory(int id, CreateUpdateCategoryDto category);
    void DeleteCategory(int id);

}