
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Areas.Admin;

[Area(("Admin"))]
public class TestResultsController : Controller
{
    private readonly IUnitOfWork _resultsRepository;

    public TestResultsController(IUnitOfWork resultsRepository)
    {
        _resultsRepository = resultsRepository;
    }
    
    public IActionResult Index()
    {
        IEnumerable<TestResult> testResults = _resultsRepository.ResultsRepository.GetAll();
        return View(testResults);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TestResult testResult)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _resultsRepository.ResultsRepository.Add(testResult);
                _resultsRepository.Save();
                TempData["success"] = "Test result created succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to create medical condition due to error.";
                return View(e.Message);
            }
        }

        return View(testResult);
    }

}