﻿namespace MayTheFourth.Services.Dto;

public record ListCharacterMovies : IResultValues
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
