using Application.Dto;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public List<CategoryDto> GetAllCategories()
    {
        var categories = _categoryRepository.GetAll();
        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public CategoryDto GetCategoryById(int id)
    {
        var category = _categoryRepository.GetById(id);
        if(category == null)
            throw new NotFoundException($"Category with id: {id} not found");

        return _mapper.Map<CategoryDto>(category);
    }

    public CategoryDto AddNewCategory(CreateUpdateCategoryDto newCategory)
    {
        var category = _mapper.Map<Category>(newCategory);
        _categoryRepository.Add(category);

        return _mapper.Map<CategoryDto>(category);
    }

    public void UpdateCategory(int id, CreateUpdateCategoryDto category)
    {
        var existingCategory = _categoryRepository.GetById(id);
        if (existingCategory == null)
            throw new NotFoundException($"Category with id: {id} not found");
        var updateCategory = _mapper.Map(category, existingCategory);

        _categoryRepository.Update(updateCategory);
    }

    public void DeleteCategory(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category == null)
            throw new NotFoundException($"Category with id: {id} not found");
        _categoryRepository.Delete(category);
    }
}