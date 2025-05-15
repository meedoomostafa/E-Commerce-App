namespace App.Models.ViewModels;

public class AddReviewsViewModel
{
    public int ProductId { get; set; }
    public byte Rating { get; set; }
    public string? Comment { get; set; }
    public string? Url { get; set; }
}