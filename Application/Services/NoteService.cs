using Application.Dto;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly IMapper _mapper;
    
    public NoteService(INoteRepository noteRepository, IMapper mapper)
    {
        _mapper = mapper;
        _noteRepository = noteRepository;
    }
    public ResultDto<NoteDto> GetAllNotes()
    {
        var notes = _noteRepository.GetAll();
        return _mapper.Map<ResultDto<NoteDto>>(notes);
    }

    public ResultDto<NoteDto> GetNotesBySearchPhrase(string searchPhrase)
    {
        var notes = _noteRepository.GetBySearchPhrase(searchPhrase);
        return _mapper.Map<ResultDto<NoteDto>>(notes);
    }

    public NoteDto GetNoteById(int id)
    {
        var note = _noteRepository.GetById(id);
        if (note == null)
            throw new NotFoundException($"Note with id: {id} not found");

        return _mapper.Map<NoteDto>(note);
    }
    public NoteDto AddNewNote(CreateNoteDto newNote)
    {
        var note = _mapper.Map<Note>(newNote);
        note.Detail = new NoteDetail()
        {
            Created = DateTime.Now,
            LastModified = DateTime.Now
        };
        _noteRepository.Add(note);

        return _mapper.Map<NoteDto>(note);
    }
    public void UpdateNote(int id, UpdateNoteDto note)
    {
        var existingNote = _noteRepository.GetById(id);
        if (existingNote == null)
            throw new NotFoundException($"Note with id: {id} not found");

        var updateNote = _mapper.Map(note, existingNote);
        updateNote.Detail.LastModified = DateTime.Now;

        _noteRepository.Update(updateNote);
    }
    public void DeleteNote(int id)
    {
        var note = _noteRepository.GetById(id);
        if (note == null)
            throw new NotFoundException($"Note with id: {id} not found");

        _noteRepository.Delete(note);
    }
}
