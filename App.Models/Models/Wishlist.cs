namespace App.Models.Models;

public class Wishlist
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public AppUser? AppUser { get; set; }
    public ICollection<WishlistItem>? Items { get; set; }
}