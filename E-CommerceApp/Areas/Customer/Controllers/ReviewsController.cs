using System.Security.Claims;
using App.Models;
using App.Models.ViewModels;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Utiltity;
using E_CommerceApp.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Areas.Customer.Controllers;

[Area(SD.RoleCustomer)]
[Authorize]
public class ReviewsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public ReviewsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [TypeFilter(typeof(CustomAuthorizeFilter))]
    public async Task<IActionResult> AddReview(AddReviewsViewModel model)
    {
        var productId = model.ProductId;
        var rating = model.Rating;
        var comment = model.Comment;
        var url = model.Url;

        var user = (ClaimsIdentity)User.Identity!;
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("user not found");
        }

        var product = await _unitOfWork.Product.GetByIdAsync(productId);
        if (product == null)
        {
            return NotFound();
        }

        if (product.Reviews == null)
        {
            product.Reviews = new List<Review>();
        }

        Review review = new Review
        {
            ProductId = productId,
            UserId = userId,
            Rating = rating,
            Comment = comment
        };

        product.Reviews.Add(review);
        await _unitOfWork.Product.Update(product);
        await _unitOfWork.SaveChanges();
        return Redirect(url ?? Url.Action("Details", "Home", new { area = "", id = productId })!);
    }
}