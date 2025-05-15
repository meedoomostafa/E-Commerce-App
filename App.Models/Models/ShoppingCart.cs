using App.Models.Models;

namespace App.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public AppUser? User { get; set; }
    public ICollection<CartItem>? Items { get; set; }
}