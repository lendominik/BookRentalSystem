using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;

namespace BookRentalSystem.Interfaces;

public interface IPublisherService
{
    Task<GetPublisherResponse> GetPublisher(int publisherId);
    Task AddPublisher(AddPublisherRequest addPublisherRequest);
    Task UpdatePublisher(int publisherId, UpdatePublisherRequest updatePublisherRequest);
    Task DeletePublisher(int publisherId);
}
