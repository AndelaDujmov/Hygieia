using Hygieia.Utils.Complex;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects.DataClasses;

[assembly: EdmSchemaAttribute()]

namespace Hygieia.Entities
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }

        [EdmComplexPropertyAttribute()]
        public Allergies Allergies { get; set; }
        public string SideEffects { get; set;}
        public bool Deleted { get; set; }

    }
}
