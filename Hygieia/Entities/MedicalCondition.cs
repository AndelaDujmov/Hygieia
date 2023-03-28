using Hygieia.Utils.Enums;

namespace Hygieia.Entities
{
    public class MedicalCondition
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Type { get; set; }
        public string Symptoms { get; set; }
        public string NameOfDiagnosys { get; set; }
        public string Treatment { get; set; }
    }
}
