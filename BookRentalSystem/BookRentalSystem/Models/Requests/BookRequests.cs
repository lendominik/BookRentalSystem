namespace BookRentalSystem.Models.Requests;

public record AddBookRequest(string title, int categoryId, int authorId, int publisherId, string description);
public record UpdateBookRequest(string title, string description);