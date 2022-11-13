using Application.Dto;

namespace Application.Interfaces;

public interface INoteService
{
    ResultDto<NoteDto> GetAllNotes();
    ResultDto<NoteDto> GetNotesBySearchPhrase(string searchPhrase);
    NoteDto GetNoteById(int id);
    NoteDto AddNewNote(CreateNoteDto newNote);
    void UpdateNote(int id, UpdateNoteDto note);
    void DeleteNote(int id);
    
}
