using App.Models.Enums;
using App.Models.Models;

namespace App.Models;

public class Order
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public AppUser? User { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<OrderItem>? Items { get; set; }
}
