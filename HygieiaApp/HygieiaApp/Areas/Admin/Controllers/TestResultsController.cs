
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Exception = System.Exception;

namespace HygieiaApp.Areas.Admin;

[Area(("Admin"))]
public class TestResultsController : Controller
{
    private readonly AdminService _service;

    public TestResultsController(AdminService service)
    {
        _service = service;
    }
    
    public IActionResult Index()
    {
        IEnumerable<TestResult> testResults = _service.ReturnAllTests();
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
                _service.CreateTestResult(testResult);
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

    public IActionResult Edit(Guid? id)
    {
        var testResult = _service.GetTestResultById(id);

        if (testResult.Equals(null))
        {
            TempData["error"] = "Unable to create model on empty data.";
            return NotFound();
        }

        return View(testResult);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(TestResult testResult)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _service.UpdateTestResult(testResult);
                TempData["success"] = "Test type updated succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to update test type due to error";
                return View(e.Message);
            }
        }

        TempData["error"] = "Unable to update test type with invalid parameter.";
        return View(testResult);
    }

    public IActionResult Delete(Guid? id)
    {
        var result = _service.GetTestResultById(id);
        
        
        if (result is null)
            return NotFound();

            return View(result);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(Guid? id)
    {

        var test = _service.GetTestResultById(id);

        if (test.Equals(null))
        {
            TempData["error"] = "Unable to remove non existent test";
            return NotFound();
        }
        
        _service.UpdateTestResult(test);
        TempData["success"] = "Test deleted succesfully.";
        return RedirectToAction("Index");
          
    }
}