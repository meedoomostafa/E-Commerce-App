using System.Security.Principal;
using App.Models.Models;

namespace App.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    // public bool IsFavorite { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
    public ICollection<Review>? Reviews{ get; set; }
    public ICollection<CartItem>? CartItems { get; set; }
    public ICollection<WishlistItem>? WishlistItems { get; set; }
}