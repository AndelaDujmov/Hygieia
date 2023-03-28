namespace Hygieia.Entities
{
    public class PatientWithConditionMedicated
    {
        public int Id { get; set; }
        public int MedicalConditionMedicationId { get; set; }
        public int PatientMedicalConditionId { get; set; }
        public decimal Dosage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public int Frequency { get; set; }
    }
}
