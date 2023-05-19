using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace HygieiaApp;

public class AdminService 
{
    private readonly IUnitOfWork _medicalConditionRepository;
    private readonly IMedicineForConditionRepository _medicineForCondition;

    public AdminService(IUnitOfWork medicalConditionRepository, IMedicineForConditionRepository medC)
    {
        _medicalConditionRepository = medicalConditionRepository;
        _medicineForCondition = medC;
    }

    public IEnumerable<MedicalCondition> ReturnAllMedicalConditions()
    {
        return _medicalConditionRepository.MedicalConditionRepository.GetAll();
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

    public IEnumerable<Medication> ReturnAllMedications()
    {
        return  _medicalConditionRepository.MedicationRepository
                                           .GetAll();
    }

    public IEnumerable<Immunization> ReturnAllVaccinations()
    {
        return _medicalConditionRepository.VaccineRepository.GetAll();
    }
    
    public IEnumerable<TestResult> ReturnAllTests()
    {
        return _medicalConditionRepository.ResultsRepository.GetAll();
    }
    
    public MedicalCondition GetConditionById(Guid? id)
    {
        return _medicalConditionRepository.MedicalConditionRepository.Get(x=> x.Id == id);
    }

    public Medication GetMedicationById(Guid? id)
    {
        return _medicalConditionRepository.MedicationRepository.Get(x=> x.Id == id);
    }

    public Immunization GetVaccineById(Guid? id)
    {
        return _medicalConditionRepository.VaccineRepository.Get(x=> x.Id == id);
    }

    public TestResult GetTestResultById(Guid? id)
    {
        return _medicalConditionRepository.ResultsRepository.Get(x=> x.Id == id);
    }

    public MedicalConditionMedication GetLinkByIdConditionId(Guid id)
    {
        MedicalConditionMedication? conditionLink = _medicalConditionRepository.MedicineForConditionRepository
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
        
        _medicalConditionRepository.MedicalConditionRepository.Add(condition);
        _medicalConditionRepository.Save();
    }
    
    public void CreateMedication(Medication medication)
    {
        var medications = ReturnAllMedications().Select(x => x.Name);
        
        if(medications.Contains(medication.Name))
            return;
        
        _medicalConditionRepository.MedicationRepository.Add(medication);
        _medicalConditionRepository.Save();
    }
    
    public void CreateVaccination(Immunization immunization)
    {
        var immunizations = ReturnAllVaccinations().Select(x => x.Type);
        
        if(immunizations.Contains(immunization.Type))
            return;
        
        _medicalConditionRepository.VaccineRepository.Add(immunization);
        _medicalConditionRepository.Save();
    }
    
    public void CreateTestResult(TestResult testResult)
    {
        var immunizations = ReturnAllTests().Select(x => x.Type);
        
        if(immunizations.Contains(testResult.Type))
            return;
        
        _medicalConditionRepository.ResultsRepository.Add(testResult);
        _medicalConditionRepository.Save();
    }

    
    public void UpdateCondition(MedicalCondition condition)
    {
        _medicalConditionRepository.MedicalConditionRepository.Update(condition);
    }

    public void UpdateMedication(Medication medication)
    {
        _medicalConditionRepository.MedicationRepository.Update(medication);
    }

    public void UpdateVaccination(Immunization immunization)
    {
        _medicalConditionRepository.VaccineRepository.Update(immunization);
    }
    
    public void UpdateTestResult(TestResult testResult)
    {
        _medicalConditionRepository.ResultsRepository.Update(testResult);
    }

    public void DeleteCondition(MedicalCondition condition)
    {
        _medicalConditionRepository.MedicalConditionRepository.Delete(condition);
        _medicalConditionRepository.Save();
    }

    public void DeleteMedication(Medication medication)
    {
        _medicalConditionRepository.MedicationRepository.Delete(medication);
        _medicalConditionRepository.Save();
    }
    
    public void DeleteVaccination(Immunization immunization)
    {
        _medicalConditionRepository.VaccineRepository.Delete(immunization);
        _medicalConditionRepository.Save();
    }
    
    public void DeleteTest(TestResult testResult)
    {
        _medicalConditionRepository.ResultsRepository.Delete(testResult);
        _medicalConditionRepository.Save();
    }

    public void LinkConditionToMed(Guid id, MedicalConditionMedication conditionMedication)
    {
        conditionMedication.MedicalConditionId = id;
        _medicalConditionRepository.MedicineForConditionRepository.Add(conditionMedication);
        _medicalConditionRepository.Save();
    }
}