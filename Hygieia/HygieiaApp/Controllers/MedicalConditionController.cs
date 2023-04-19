using HygieiaApp.Data;
using HygieiaApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace HygieiaApp.Controllers;

public class MedicalConditionController : Controller
{
    private readonly AppDbContext _appDb = new AppDbContext();


    public MedicalConditionController( )
    {
       
    }
    public IActionResult Index()
    {
        IEnumerable<MedicalCondition> medicalConditions = _appDb.MedicalConditions;
        
        return View(medicalConditions);
    }
    
    //GET
    public IActionResult Create()
    {
        return View();
    }
    
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(MedicalCondition condition)
    {
        _appDb.MedicalConditions.Add(condition);
        _appDb.SaveChanges();
        return RedirectToAction("Index");
    }
    
}