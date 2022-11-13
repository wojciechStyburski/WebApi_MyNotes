using Domain.Entities;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
    List<Category> GetAll();
    Category GetById(int id);
    Category GetByName(string name);
    Category Add(Category category);
    void Update(Category category);
    void Delete(Category category);
}