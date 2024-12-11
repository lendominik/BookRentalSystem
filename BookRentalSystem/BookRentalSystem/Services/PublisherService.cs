using BookRentalSystem.Entities;
using BookRentalSystem.Exceptions;
using BookRentalSystem.Models.Requests;
using BookRentalSystem.Models.Responses;
using BookRentalSystem.Persistence;
using BookRentalSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookRentalSystem.Services;

[Service(ServiceLifetime.Scoped)]
public class PublisherService(AppDbContext dbContext) : IPublisherService
{
    public async Task AddPublisher(AddPublisherRequest addPublisherRequest)
    {
        var publisher = new Publisher
        {
            Name = addPublisherRequest.name,
            Description = addPublisherRequest.description
        };

        await dbContext.Publishers.AddAsync(publisher);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeletePublisher(int publisherId)
    {
        var publisher = await dbContext.Publishers.FirstOrDefaultAsync(p => p.Id == publisherId);

        if (publisher is null)
        {
            throw new NotFoundException("Publisher not found");
        }

        dbContext.Publishers.Remove(publisher);
        await dbContext.SaveChangesAsync();
    }

    public async Task<GetPublisherResponse> GetPublisher(int publisherId)
    {
        var publisher = await dbContext.Publishers.FirstOrDefaultAsync(p => p.Id == publisherId);

        if (publisher is null)
        {
            throw new NotFoundException("Publisher not found");
        }

        return new GetPublisherResponse(publisher.Name, publisher.Description);
    }

    public async Task UpdatePublisher(int publisherId, UpdatePublisherRequest updatePublisherRequest)
    {
        var publisher = await dbContext.Publishers.FirstOrDefaultAsync(p => p.Id == publisherId);

        if (publisher is null)
        {
            throw new NotFoundException("Publisher not found");
        }

        publisher.Name = updatePublisherRequest.name;
        publisher.Description = updatePublisherRequest.description;

        await dbContext.SaveChangesAsync();
    }
}