namespace Infrastructure.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly MyNotesContext _myNotesContext;
    public NoteRepository(MyNotesContext myNotesContext)
    {
        _myNotesContext = myNotesContext;
    }
    public List<Note> GetAll()
    {
        var notes = _myNotesContext
            .Notes
            .Include(n => n.Detail)
            .Include(n => n.Category)
            .ToList();
        
        return notes;
    }
    public List<Note> GetBySearchPhrase(string searchPhrase)
    {
        searchPhrase = searchPhrase.ToLowerInvariant();
        var notes = _myNotesContext
            .Notes
            .Include(n => n.Category)
            .Where(n =>
                n.Title.ToLower().Contains(searchPhrase) ||
                n.Content.ToLower().Contains(searchPhrase))
            .ToList();

        return notes;
    }
    public Note GetById(int id)
    {
        var note = _myNotesContext
            .Notes
            .Include(n => n.Detail)
            .Include(n => n.Category)
            .FirstOrDefault(n => n.Id == id);
        
        return note;
    }
    public Note Add(Note note)
    {
        _myNotesContext.Notes.Add(note);
        _myNotesContext.SaveChanges();

        return note;
    }
    public void Update(Note note)
    {
        _myNotesContext.Notes.Update(note);
        _myNotesContext.SaveChanges();
    }
    public void Delete(Note note)
    {
        _myNotesContext.Notes.Remove(note);
        _myNotesContext.SaveChanges();
    }
}
