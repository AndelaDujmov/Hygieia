using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Enums;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.Cosmos.Linq;

namespace HygieiaApp;

public class AdminService 
{
    private readonly IUnitOfWork _repository;
    private readonly IMedicineForConditionRepository _medicineForCondition;
    private readonly UserManager<IdentityUser> _userManager;

    public AdminService(IUnitOfWork medicalConditionRepository, IMedicineForConditionRepository medC, UserManager<IdentityUser> userManager)
    {
        _repository = medicalConditionRepository;
        _medicineForCondition = medC;
        _userManager = userManager;
    }

    public IEnumerable<MedicalCondition> ReturnAllMedicalConditions()
    {
        return _repository.MedicalConditionRepository.GetAll().Where(x => x.Deleted.Equals(false));
    }

    public IEnumerable<MedicalCondition> ReturnAllDeletedConditions()
    {
        return _repository.MedicalConditionRepository.GetAll().Where(x => x.Deleted.Equals(true));
    }
    public IEnumerable<MedicalConditionMedication>? ReturnMedicationsByCondition(Guid id)
    {
        var list =  _repository.MedicineForConditionRepository.GetAll();

        if (list != null)
        {
            list = list.Where(x => x.MedicalConditionId.Equals(id) && x.Deleted.Equals(false));
            list.Where(x => !x.MedicalConditionId.Equals(Guid.Empty)).ToList().ForEach(e => e.NameOfMedication = ReturnNameOfMedication(e.MedicationId));
        }

        return list;
    }

    public IEnumerable<ApplicationUser> ReturnAllUsers()
    {
        return _repository.ApplicationUserRepository.GetUsers().Where(x => !x.Deleted);
    }
    

    public string GetRolenameByUser(string id)
    {
        return _repository.ApplicationUserRepository.GetRoleByUser(id);
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
                                           .GetAll()
                                           .Where(x => x.Deleted.Equals(false));
    }

    public IEnumerable<Medication> ReturnAllDeletedMedications()
    {
        return  _repository.MedicationRepository
            .GetAll()
            .Where(x => x.Deleted.Equals(true));
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
        return _repository.ApplicationUserRepository.GetUsers().Where(x => x.Id.Equals(id) && !x.Deleted)
                                                    .First();
    }

    public MedicalConditionMedication GetMedicationForCondition(Guid id)
    {
        return _repository.MedicineForConditionRepository.Get(x => x.Id.Equals(id));
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

    public void UpdateMedicationForCondition(MedicalConditionMedication medicalConditionMedication)
    {
        if(ReturnMedicationsByCondition(medicalConditionMedication.MedicalConditionId) is null)
            _repository.MedicineForConditionRepository.Add(medicalConditionMedication);
        else 
            _repository.MedicineForConditionRepository.Update(medicalConditionMedication);
    }
    
    public void DeleteCondition(MedicalCondition condition)
    {
        condition.Deleted = true;
        _repository.MedicalConditionRepository.Update(condition);
        _repository.Save();
    }

    public void DeleteMedication(Medication medication)
    {
        medication.Deleted = true;
        _repository.MedicationRepository.Update(medication);
        _repository.Save();
    }
    
    public void DeleteVaccination(Immunization immunization)
    {
        var patientsImmunization = _repository.VaccinePatientRepository.GetAll()
            .Where(x => x.ImmunizationId.Equals(immunization.Id));
        
        patientsImmunization.ToList().ForEach(x =>
        {
            _repository.VaccinePatientRepository.Delete(x);
        });
        _repository.VaccineRepository.Delete(immunization);
        _repository.Save();
    }

    public void LinkConditionToMed(Guid id, MedicalConditionMedication conditionMedication)
    {
        conditionMedication.MedicalConditionId = id;
        _repository.MedicineForConditionRepository.Add(conditionMedication);
        _repository.Save();
    }

    public void UpdateUser(ApplicationUser user)
    {
        _repository.ApplicationUserRepository.UpdateUser(user);
    }

    public void DeleteUser(string id)
    {
        var user = _repository.ApplicationUserRepository.Get(x => x.Id.Equals(id));

        user.Deleted = true;
        _repository.Save();
    }

    public IEnumerable<ApplicationUser> DeletedUsers()
    {
        return _repository.ApplicationUserRepository.GetUsers().Where(x => x.Deleted);
    }

    public void Undo(string id)
    {
        var user = _repository.ApplicationUserRepository.Get(x => x.Id.Equals(id));

        user.Deleted = false;
        _repository.Save();
    }
    
    public void UndoMedicalC(Guid id)
    {
        var condition = _repository.MedicalConditionRepository.Get(x => x.Id.Equals(id));

        condition.Deleted = false;
        _repository.Save();
    }
    
    [Authorize]
    public void UndoMedication(Guid id)
    {
        var med = _repository.MedicationRepository.Get(x => x.Id.Equals(id));

        med.Deleted = false;
        _repository.Save();
    }
    
    private string? ReturnNameOfMedication(Guid id) 
    {
        var medication = _repository.MedicationRepository.Get(x => x.Id.Equals(id));

        return medication.Name ?? string.Empty; 
    }
      
      
}