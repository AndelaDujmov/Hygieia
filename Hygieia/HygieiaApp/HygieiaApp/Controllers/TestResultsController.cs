using HygieiaApp.Data;
using HygieiaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

public class TestResultsController : Controller
{
    private readonly AppDbContext _appDb = new AppDbContext();
    
    public IActionResult Index()
    {
        IEnumerable<TestResult> testResults = _appDb.TestResults;
        return View(testResults);
    }
}