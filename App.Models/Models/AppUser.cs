using System.ComponentModel.DataAnnotations;
using App.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace App.Models;

public class AppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Role { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }
    public Wishlist? Wishlist { get; set; }
}