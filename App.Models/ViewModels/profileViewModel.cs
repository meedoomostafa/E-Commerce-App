using App.Models.Models;

namespace App.Models.ViewModels;

public class ProfileViewModel
{
    public AppUser? User;
    public ICollection<CartItem>? CartItems;
    public ICollection<WishlistItem>? WishlistItems;
}