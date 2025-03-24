using App.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace App.Models;

public class AppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }
}