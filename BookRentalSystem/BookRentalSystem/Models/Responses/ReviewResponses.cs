namespace BookRentalSystem.Models.Responses;

public record GetReviewResponse(string content, string reviewerName, DateTime createdDate);