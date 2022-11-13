namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly MyNotesContext _myNotesContext;

    public CategoryRepository(MyNotesContext myNotesContext)
    {
        _myNotesContext = myNotesContext;
    }
    public List<Category> GetAll()
    {
        return _myNotesContext.Categories.ToList();
    }

    public Category GetById(int id)
    {
        return _myNotesContext.Categories.FirstOrDefault(c => c.Id == id);
    }

    public Category GetByName(string name)
    {
        return _myNotesContext.Categories.SingleOrDefault(c => c.Name.ToLower() == name.ToLower());
    }

    public Category Add(Category category)
    {
        _myNotesContext.Categories.Add(category);
        _myNotesContext.SaveChanges();

        return category;
    }

    public void Update(Category category)
    {
        _myNotesContext.Categories.Update(category);
        _myNotesContext.SaveChanges();
    }

    public void Delete(Category category)
    {
        _myNotesContext.Categories.Remove(category);
        _myNotesContext.SaveChanges();
    }
}