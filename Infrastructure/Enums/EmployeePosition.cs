using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Enums
{
    public enum EmployeePosition
    {
        [Display(Name = "CEO")]
        CEO = 1,
        [Display(Name = "AGE")]
        AGE = 2,
    }
}
