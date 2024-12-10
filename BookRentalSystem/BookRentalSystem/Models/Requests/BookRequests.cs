namespace BookRentalSystem.Models.Requests;

public record AddBookRequest(string title, int categoryId, int authorId);
public record UpdateBookRequest(int id, string title, string description);
public record DeleteBookRequest(int id);