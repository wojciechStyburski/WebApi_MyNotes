using Domain.Entities;

namespace Domain.Interfaces;

public interface INoteRepository
{
    List<Note> GetAll();
    List<Note> GetBySearchPhrase(string searchPhrase);
    Note GetById(int id);
    Note Add(Note note);
    void Update(Note note);
    void Delete(Note note);
}
