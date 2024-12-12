﻿namespace BookRentalSystem.Entities;

public class Review
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public string ReviewerName { get; set; } = "Anonymous";
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public int BookId { get; set; }
    public virtual Book Book { get; set; } = null!;
}