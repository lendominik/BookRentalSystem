using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class BaseEntity
{
    public int Id { get; set; }

    public string? CreatedById { get; set; }
    public IdentityUser? CreatedBy { get; set; }
}