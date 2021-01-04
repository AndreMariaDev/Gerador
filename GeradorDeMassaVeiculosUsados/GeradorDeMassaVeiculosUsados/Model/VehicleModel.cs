using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace App.Domain.Models
{
    public class VehicleModel : DomainEntity
    {
        [JsonPropertyName("code")]
        public long Code { get; set; }
        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("codeBrand")]
        public long CodeBrand { get; set; }

        [JsonPropertyName("brand")]
        public Brand Brand { get; set; }
    }
}
