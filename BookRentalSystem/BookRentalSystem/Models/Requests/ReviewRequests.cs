namespace BookRentalSystem.Models.Requests;

public record AddReviewRequest(string reviewerName, string content, int bookId);