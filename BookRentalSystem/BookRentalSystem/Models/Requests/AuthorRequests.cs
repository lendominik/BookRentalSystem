namespace BookRentalSystem.Models.Requests;

public record AddAuthorRequest(string firstName, string lastName, string? description, string? nationality, DateTime? dateOfBirth, DateTime? dateOfDeath);
public record UpdateAuthorRequest(string? description);