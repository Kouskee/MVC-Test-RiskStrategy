using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infrastructure.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Company name")]
        public string Name { get; set; } = null!;
        public string Adress { get; set; } = null!;
        [JsonConverter(typeof(StringEnumConverter))]
        public Cities City { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public States State { get; set; }
        public string Phone { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<CompanyOrder> History { get; set; } = new List<CompanyOrder>();
        public virtual ICollection<CompanyNote> Notes { get; set; } = new List<CompanyNote>();
    }
}
