﻿namespace BookRentalSystem.Entities;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public virtual List<Book> Books { get; set; } = [];
}