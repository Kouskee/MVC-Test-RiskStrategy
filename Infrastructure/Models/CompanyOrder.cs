using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class CompanyOrder
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Order Date")]
        public DateOnly OrderDate { get; set; }
        [JsonProperty(PropertyName = "Store City")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Cities StoreCity { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;
    }
}
