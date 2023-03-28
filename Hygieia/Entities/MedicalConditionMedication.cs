namespace Hygieia.Entities
{
    public class MedicalConditionMedication
    {   
        public int Id { get; set; }
        public int MedicalConditionId { get; set; }
        public MedicalCondition MedicalCondition { get; set; }
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }
        public decimal MaximumDosage { get; set; }
    }
}
