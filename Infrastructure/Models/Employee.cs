using System.ComponentModel.DataAnnotations;
using Infrastructure.Enums;
using Newtonsoft.Json;

namespace Infrastructure.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "First Name")]
        public string FirstName { get; set; } = null!;
        [JsonProperty(PropertyName = "Last Name")]
        public string LastName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public EmployeePosition Position { get; set; }

        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
