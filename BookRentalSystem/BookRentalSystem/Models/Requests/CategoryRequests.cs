namespace BookRentalSystem.Models.Requests;

public record AddCategoryRequest(string name, string? description);
public record UpdateCategoryRequest(string name, string? description);