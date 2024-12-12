using BookRentalSystem.Models.Requests;
using BookRentalSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

[Route("api/v1/publisher")]
[ApiController]
public class PublisherController(IPublisherService publisherService) : ControllerBase
{
    [HttpGet("{publisherId}")]
    public async Task<IActionResult> GetPublisher([FromRoute]int publisherId)
    {
        var publisher = await publisherService.GetPublisher(publisherId);
        return Ok(publisher);
    }

    [HttpDelete("{publisherId}")]
    public async Task<IActionResult> DeletePublisher([FromRoute]int publisherId)
    {
        await publisherService.DeletePublisher(publisherId);
        return Ok();
    }

    [HttpPut("{publisherId}")]
    public async Task<IActionResult> UpdatePublisher([FromRoute]int publisherId, [FromBody]UpdatePublisherRequest updatePublisherRequest)
    {
        await publisherService.UpdatePublisher(publisherId, updatePublisherRequest);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddPublisher([FromBody] AddPublisherRequest addPublisherRequest)
    {
        await publisherService.AddPublisher(addPublisherRequest);
        return Ok();
    }
}
