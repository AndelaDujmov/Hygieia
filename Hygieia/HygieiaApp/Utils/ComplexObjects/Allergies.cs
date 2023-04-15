using System.Data.Entity.Core.Objects.DataClasses;
using HygieiaApp.Utils.Enums;
using Microsoft.EntityFrameworkCore;

namespace HygieiaApp.Utils.ComplexObjects;

[EdmComplexType(NamespaceName =
    "HygieiaApp.Utils.Enums", Name = "Allergies")]
[Keyless]
public class Allergies
{
   
    [EdmScalarPropertyAttribute(IsNullable = true)]
    public AllergySeverity Severity { get; set; }
    [EdmScalarPropertyAttribute(IsNullable = true)]
    public string ReactionType { get; set; }
}
