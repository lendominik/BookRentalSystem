namespace Core.Models.Responses;

public record GetAuthorResponse(string firstName, string lastName, string? description, string? nationality, DateTime? dateOfBith, DateTime? dateOfDeath);