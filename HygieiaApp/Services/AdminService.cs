using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace HygieiaApp;

public class AdminService 
{
    private readonly IUnitOfWork _repository;
    private readonly IMedicineForConditionRepository _medicineForCondition;

    public AdminService(IUnitOfWork medicalConditionRepository, IMedicineForConditionRepository medC)
    {
        _repository = medicalConditionRepository;
        _medicineForCondition = medC;
    }

    public IEnumerable<MedicalCondition> ReturnAllMedicalConditions()
    {
        return _repository.MedicalConditionRepository.GetAll();
    }

    public IEnumerable<ApplicationUser> ReturnAllUsers()
    {
        return _repository.ApplicationUserRepository.GetAll();
    }

    public IEnumerable<SelectListItem> MedicationNameSelectList()
    {
        var items = ReturnAllMedications();

        return items.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Name
        });
    }

    public IEnumerable<SelectListItem> TestNamesSelectList()
    {
        var testNames = ReturnAllTests();

        return testNames.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Type
        });
    }

    public IEnumerable<Medication> ReturnAllMedications()
    {
        return  _repository.MedicationRepository
                                           .GetAll();
    }

    public IEnumerable<Immunization> ReturnAllVaccinations()
    {
        return _repository.VaccineRepository.GetAll();
    }
    
    public IEnumerable<TestResult> ReturnAllTests()
    {
        return _repository.ResultsRepository.GetAll();
    }
    
    public MedicalCondition GetConditionById(Guid? id)
    {
        return _repository.MedicalConditionRepository.Get(x=> x.Id == id);
    }

    public Medication GetMedicationById(Guid? id)
    {
        return _repository.MedicationRepository.Get(x=> x.Id == id);
    }

    public Immunization GetVaccineById(Guid? id)
    {
        return _repository.VaccineRepository.Get(x=> x.Id == id);
    }

    public TestResult GetTestResultById(Guid? id)
    {
        return _repository.ResultsRepository.Get(x=> x.Id == id);
    }

    public ApplicationUser? GetUserById(string? id)
    {
        return _repository.ApplicationUserRepository.Get(user => user.Id.Equals(id));
    }
    public MedicalConditionMedication GetLinkByIdConditionId(Guid id)
    {
        MedicalConditionMedication? conditionLink = _repository.MedicineForConditionRepository
                                          .GetAll()
                                          .Where(x => 
                                              x.MedicalConditionId.Equals(id)).FirstOrDefault();

        return conditionLink ?? new MedicalConditionMedication();
    }
    
    public void CreateCondition(MedicalCondition condition)
    {
        var diagnosisList = ReturnAllMedicalConditions().Select(x => x.NameOfDiagnosis);
        
        if(diagnosisList.Contains(condition.NameOfDiagnosis))
            return;
        
        _repository.MedicalConditionRepository.Add(condition);
        _repository.Save();
    }
    
    public void CreateMedication(Medication medication)
    {
        var medications = ReturnAllMedications().Select(x => x.Name);
        
        if(medications.Contains(medication.Name))
            return;
        
        _repository.MedicationRepository.Add(medication);
        _repository.Save();
    }
    
    public void CreateVaccination(Immunization immunization)
    {
        var immunizations = ReturnAllVaccinations().Select(x => x.Type);
        
        if(immunizations.Contains(immunization.Type))
            return;
        
        _repository.VaccineRepository.Add(immunization);
        _repository.Save();
    }
    
    public void CreateTestResult(TestResult testResult)
    {
        var immunizations = ReturnAllTests().Select(x => x.Type);
        
        if(immunizations.Contains(testResult.Type))
            return;
        
        _repository.ResultsRepository.Add(testResult);
        _repository.Save();
    }

    
    public void UpdateCondition(MedicalCondition condition)
    {
        _repository.MedicalConditionRepository.Update(condition);
    }

    public void UpdateMedication(Medication medication)
    {
        _repository.MedicationRepository.Update(medication);
    }

    public void UpdateVaccination(Immunization immunization)
    {
        _repository.VaccineRepository.Update(immunization);
    }
    
    public void UpdateTestResult(TestResult testResult)
    {
        _repository.ResultsRepository.Update(testResult);
    }
    
    public void DeleteCondition(MedicalCondition condition)
    {
        _repository.MedicalConditionRepository.Delete(condition);
        _repository.Save();
    }

    public void DeleteMedication(Medication medication)
    {
        _repository.MedicationRepository.Delete(medication);
        _repository.Save();
    }
    
    public void DeleteVaccination(Immunization immunization)
    {
        _repository.VaccineRepository.Delete(immunization);
        _repository.Save();
    }
    
    public void DeleteTest(TestResult testResult)
    {
        _repository.ResultsRepository.Delete(testResult);
        _repository.Save();
    }

    public void LinkConditionToMed(Guid id, MedicalConditionMedication conditionMedication)
    {
        conditionMedication.MedicalConditionId = id;
        _repository.MedicineForConditionRepository.Add(conditionMedication);
        _repository.Save();
    }
}