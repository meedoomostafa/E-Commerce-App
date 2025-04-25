using App.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using E_CommerceApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.RoleAdmin)]
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var products = await _unitOfWork.Product
                .GetAllAsync(null,q=> q.Include(p => p.Category));
            return View(nameof(Index),products);
        }
        catch (Exception)
        {
            TempData["Error"] = "Something went wrong";
            return View(nameof(Index),new List<Product>());
        }
    }

    public async Task<IActionResult> Create()
    {
        var Categories = await _unitOfWork.Category.GetAllAsync();
        ViewBag.Categories = new SelectList(Categories, "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product,IFormFile imageFile)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    if (imageFile.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("imageFile", "File size is too large , maximum size is 5MB");
                        var categories = await _unitOfWork.Category.GetAllAsync();
                        ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
                        return View(product);
                    }
                    var allowedExtensions = new [] { ".jpg", ".png", ".gif" , ".jpeg" };
                    var extension = Path.GetExtension(imageFile.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("imageFile", "File extension is not valid");
                        var categories = await _unitOfWork.Category.GetAllAsync();
                        ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
                        return View(product);
                    }
                    var fileName = Guid.NewGuid().ToString() + extension;
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    product.ImageUrl = "/images/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("imageFile", "please upload an image file");
                    var categories = await _unitOfWork.Category.GetAllAsync();
                    ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
                    return View(product);
                }
                await _unitOfWork.Product.Add(product);
                await _unitOfWork.SaveChanges();
                TempData["Success"] = "Product added";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = $"An error occured : {e.Message}";
            }
            return RedirectToAction(nameof(Index));    
        }
        var Categories = await _unitOfWork.Category.GetAllAsync();
        ViewBag.Categories = new SelectList(Categories, "Id", "Name");
        return View(nameof(Create),product);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var product = await _unitOfWork.Product.GetByIdAsync(id.Value);
        if (product == null)
        {
            return NotFound();
        }
        var Categories = await _unitOfWork.Category.GetAllAsync();
        ViewBag.Categories = new SelectList(Categories, "Id", "Name");
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id , Product product , IFormFile imageFile)
    {
        if (id != product.Id)
        {
            return NotFound();
        }
        
        if (ModelState.IsValid)
        {
            try
            {
                var existingProduct = await _unitOfWork.Product.GetByIdAsync(product.Id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                if (imageFile != null && imageFile.Length > 0)
                {
                    if (imageFile.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("imageFile", "File size is too large , maximum size is 5MB");
                        var categories = await _unitOfWork.Category.GetAllAsync();
                        ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
                        return View(product);
                    }

                    var allowedExtensions = new[] { ".jpg", ".png", ".gif" };
                    var extension = Path.GetExtension(imageFile.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("imageFile", "File extension is not valid");
                        var categories = await _unitOfWork.Category.GetAllAsync();
                        ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
                        return View(product);
                    }

                    if (!string.IsNullOrEmpty(existingProduct.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images",
                            existingProduct.ImageUrl.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    var fileName = Guid.NewGuid().ToString() + extension;
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    product.ImageUrl = "/images/" + fileName;
                }
                else
                {
                    product.ImageUrl = existingProduct.ImageUrl;
                }
                await _unitOfWork.Product.Update(product);
                await _unitOfWork.SaveChanges();
                TempData["Success"] = "Product edited";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = $"An error occured : {e.Message}";
            }
        }
        var Categories = await _unitOfWork.Category.GetAllAsync();
        ViewBag.Categories = new SelectList(Categories, "Id", "Name");
        return View(product);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var product = await _unitOfWork.Product
            .GetByIdAsync(id.Value,q=>q.Include(p => p.Category));
        if (product == null)
        {
            return NotFound();
        }
        var Categories = await _unitOfWork.Category.GetAllAsync();
        ViewBag.Categories = new SelectList(Categories, "Id", "Name");
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Product product)
    {
        try
        {
            var Product = await _unitOfWork.Product.GetByIdAsync(product.Id);
            if (Product == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", product.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            _unitOfWork.Product.Delete(Product);
            await _unitOfWork.SaveChanges();
            TempData["Success"] = "Product deleted";
        }
        catch (Exception e)
        {
            TempData["Error"] = $"An error occured : {e.Message}";
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Detail(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var product = await _unitOfWork.Product
            .GetByIdAsync(id.Value,q=>q.Include(p => p.Category));

        if (product == null)
        {
            return NotFound();
        }
        
        return View(nameof(Detail),product);
    }
}