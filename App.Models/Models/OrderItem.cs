using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderHeaderId { get; set; }
    public Order? OrderHeader { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int Count { get; set; }
    public double Price { get; set; }
}