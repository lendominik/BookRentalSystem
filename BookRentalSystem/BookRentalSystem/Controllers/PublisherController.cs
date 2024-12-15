using BookRentalSystem.Models.Requests;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/publisher")]
[ApiController]
public class PublisherController(IGenericRepository<Publisher> repository) : ControllerBase
{
    [HttpGet("{publisherId}")]
    public async Task<IActionResult> GetPublisher([FromRoute]int publisherId)
    {
        var publisher = await repository.GetByIdAsync(publisherId);

        if (publisher is null) return NotFound("Publisher not found");

        return Ok(publisher);
    }

    [HttpDelete("{publisherId}")]
    public async Task<IActionResult> DeletePublisher([FromRoute]int publisherId)
    {
        var publisher = await repository.GetByIdAsync(publisherId);

        if (publisher is null) return NotFound("Publisher not found");

        repository.Delete(publisher);

        if (await repository.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem deleting the publisher");
    }

    [HttpPut("{publisherId}")]
    public async Task<IActionResult> UpdatePublisher([FromRoute]int publisherId, [FromBody]UpdatePublisherRequest updatePublisherRequest)
    {
        var publisher = await repository.GetByIdAsync(publisherId);

        if (publisher is null) return NotFound("Publisher not found");

        publisher.Name = updatePublisherRequest.name;
        publisher.Description = updatePublisherRequest.description;

        repository.Update(publisher);

        if (await repository.SaveAllAsync())
        {
            return NoContent();
        }

        return BadRequest("Problem updating the publisher");
    }

    [HttpPost]
    public async Task<IActionResult> AddPublisher([FromBody] AddPublisherRequest addPublisherRequest)
    {
        var publisher = new Publisher
        {
            Name = addPublisherRequest.name,
            Description = addPublisherRequest.description
        };

        repository.Add(publisher);

        if (await repository.SaveAllAsync())
        {
            return CreatedAtAction(nameof(GetPublisher), new { publisherId = publisher.Id }, publisher);
        }

        return BadRequest("Problem creating publisher");
    }
}
