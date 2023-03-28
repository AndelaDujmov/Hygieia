using Hygieia.Utils.Enums;

namespace Hygieia.Entities
{
    public class PatientMedicalCondition
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedicalConditionId { get; set; }
        public List<string> PastConditions { get; set; }
        public List<string> CurrentConditions { get; set; }
        public DateOnly DateOfDiagnosys { get; set; }
        public Stage Stage { get; set; }

    }
}
