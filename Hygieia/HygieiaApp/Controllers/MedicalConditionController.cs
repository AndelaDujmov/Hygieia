using HygieiaApp.Data;
using HygieiaApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace HygieiaApp.Controllers;

public class MedicalConditionController : Controller
{
    private readonly AppDbContext _appDb;


    public MedicalConditionController(/*AppDbContext appDb*/)
    {
        //_appDb = appDb;
    }
    public IActionResult Index()
    {
        //IEnumerable<MedicalCondition> medicalConditions = _appDb.MedicalConditions;
        
        return View(/*medicalConditions*/);
    }
    
    public IActionResult Create()
    {
        return View();
    }
}