namespace BookRentalSystem.Models.Requests;

public record AddBookRequest(string title, int categoryId, int authorId, int publisherId, string description);
public record UpdateBookRequest(int bookId, string title, string description);