using System;
using System.Collections.Generic;

namespace AP.Data.Models;

public partial class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public User()
    {
        Accounts = new List<Account>();
        Notifications = new List<Notification>();
    }

    // Método de validación blank spaces
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Username) &&
               !string.IsNullOrWhiteSpace(Password) &&
               !string.IsNullOrWhiteSpace(Email);
    }
}
