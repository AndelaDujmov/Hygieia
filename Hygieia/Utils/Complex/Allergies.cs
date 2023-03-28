using Hygieia.Utils.Enums;
using System.Data.Entity.Core.Objects.DataClasses;



namespace Hygieia.Utils.Complex
{
    [EdmComplexTypeAttribute(NamespaceName = "Hygieia.Utils.Complex", Name = "Allergies")]

    public class Allergies : ComplexObject
    {
        public Severity Severity { get; set; }
        public string ReactionType { get; set; }
        public bool Deleted { get; set; }
    }
}
