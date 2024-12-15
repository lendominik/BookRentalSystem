namespace Core.Models.Requests;

public record AddReviewRequest(string reviewerName, string content, int bookId);