namespace Core.Models.Requests;

public record AddPublisherRequest(string name, string? description);
public record UpdatePublisherRequest(string name, string? description);