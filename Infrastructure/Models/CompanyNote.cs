using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class CompanyNote
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Invoice Number")]
        public int InvoiceNumber { get; set; }
        public string Employee { get; set; } = null!;

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;
    }
}
