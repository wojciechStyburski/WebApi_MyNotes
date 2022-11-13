using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
	private readonly INoteService _noteService;
	public NoteController(INoteService noteService)
	{
		_noteService = noteService;
	}

	[HttpGet]
	public IActionResult GetAllNotes()
	{
		var notes = _noteService.GetAllNotes();
		return Ok(notes);
	}

    [HttpGet("search")]
    public IActionResult GetNotesBySearchPhrase([FromQuery] string searchPhrase)
    {
        var notes = _noteService.GetNotesBySearchPhrase(searchPhrase);
        return Ok(notes);
    }

	[HttpGet("{id}")]
	public IActionResult GetNoteById(int id)
	{
		var note = _noteService.GetNoteById(id);
		return Ok(note);
    }

	[HttpPost]
	public IActionResult CreateNote(CreateNoteDto createNoteDto)
	{
		var note = _noteService.AddNewNote(createNoteDto);
		return Created($"api/notes/{note.Id}", note);
	}

	[HttpPut("{id}")]
	public IActionResult UpdateNote(int id, UpdateNoteDto updateNoteDto)
	{
		var noteToUpdate = _noteService.GetNoteById(id);
		_noteService.UpdateNote(noteToUpdate.Id, updateNoteDto);
		return NoContent();
	}

    [HttpDelete("{id}")]
    public IActionResult DeleteNote(int id)
    {
		_noteService.DeleteNote(id);
        return NoContent();
    }
}
