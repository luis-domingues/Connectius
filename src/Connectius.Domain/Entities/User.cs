﻿namespace Connectius.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string DisplayName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
