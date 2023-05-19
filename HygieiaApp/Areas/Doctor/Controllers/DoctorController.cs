using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HygieiaApp.Areas.Doctor;

[Area(("Doctor"))]
public class DoctorController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public DoctorController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        var tests = _unitOfWork.ResultsRepository
                                    .GetAll()
                                    .Select(x => new SelectListItem
                                    {
                                        Text = x.Type
                                    });
        
        var viewModel = new TestUserDto();
        viewModel.TypeOfTest = tests;

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TestUserDto UserTest)
    {
        return View();
    }
}  