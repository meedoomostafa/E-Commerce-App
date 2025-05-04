using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderHeaderId { get; set; }
    public OrderHeader? OrderHeader { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int Count { get; set; }
    public double Price { get; set; }
}