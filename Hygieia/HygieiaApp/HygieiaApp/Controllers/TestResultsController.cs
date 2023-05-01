using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

public class TestResultsController : Controller
{
    private readonly IResultsRepository _resultsRepository;

    public TestResultsController(IResultsRepository resultsRepository)
    {
        _resultsRepository = resultsRepository;
    }
    
    public IActionResult Index()
    {
        IEnumerable<TestResult> testResults = _resultsRepository.GetAll();
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
                _resultsRepository.Add(testResult);
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