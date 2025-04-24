using App.Repositories.AppRepository.RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers;

public class ProfileController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public ProfileController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public IActionResult Index()
    {
        return View();
    }
}