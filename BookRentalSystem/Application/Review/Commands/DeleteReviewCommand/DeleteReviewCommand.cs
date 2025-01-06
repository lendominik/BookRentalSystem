using MediatR;

namespace Application.Review.Commands.DeleteReviewCommand;

public record DeleteReviewCommand(int ReviewId) : IRequest;