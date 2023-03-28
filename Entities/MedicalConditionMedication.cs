namespace Hygieia.Entities
{
    public class MedicalConditionMedication
    {   
        public int Id { get; set; }
        public int MedicalConditionId { get; set; }
        public int MedicationId { get; set; }
        public decimal MaximumDosage { get; set; }

    }
}
