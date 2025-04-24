using System.Diagnostics;
using App.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;
using E_CommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var products = await 
            _unitOfWork.Product.GetAllAsync(include: q=>q.Include(c => c.Category));
        return View(products);
    }

    public async Task<IActionResult> Details(int? id)
    {
        var product = await _unitOfWork.Product
            .GetByIdAsync(id.Value, include: q=>q.Include(c => c.Category));
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}