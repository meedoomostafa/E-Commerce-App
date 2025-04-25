using App.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using E_CommerceApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.RoleAdmin)]
public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _unitOfWork.Category.GetAllAsync();
        return View(nameof(Index),categories);
    }

    public IActionResult Create()
    {
        return View(nameof(Create));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _unitOfWork.Category.Add(category);
                await _unitOfWork.SaveChanges();
                TempData["Success"] = "Category added successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = $"An error occured : {e.Message}";
            }
        }
        return View(nameof(Create), category);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var category = await _unitOfWork.Category.GetByIdAsync(id.Value);
        if (category == null)
        {
            return NotFound();
        }
        return View(nameof(Edit), category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _unitOfWork.Category.Update(category);
                await _unitOfWork.SaveChanges();
                TempData["Success"] = "Category updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = $"An error occured : {e.Message}";
            }
        }
        return View(nameof(Edit), category);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var category = await _unitOfWork.Category.GetByIdAsync(id.Value);
        if (category == null)
        {
            return NotFound();
        }
        return View(nameof(Delete), category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Category category)
    {
        try
        {
            _unitOfWork.Category.Delete(category);
            await _unitOfWork.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            TempData["Error"] = $"An error occured : {e.Message}";
        }
        return View(nameof(Delete), category);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var category = await _unitOfWork.Category.GetByIdAsync(id.Value);
        if (category == null)
        {
            return NotFound();
        }
        return View(nameof(Details), category);
    }
}