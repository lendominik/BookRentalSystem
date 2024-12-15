using Core.Models.Requests;
using Core.Models.Responses;

namespace Core.Interfaces;

public interface IPublisherService
{
    Task<GetPublisherResponse> GetPublisher(int publisherId);
    Task AddPublisher(AddPublisherRequest addPublisherRequest);
    Task UpdatePublisher(int publisherId, UpdatePublisherRequest updatePublisherRequest);
    Task DeletePublisher(int publisherId);
}
