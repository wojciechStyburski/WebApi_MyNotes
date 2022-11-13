﻿namespace Application.Dto;

public class NoteDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime LastModified { get; set; }
    public CategoryDto Category { get; set; }
}
