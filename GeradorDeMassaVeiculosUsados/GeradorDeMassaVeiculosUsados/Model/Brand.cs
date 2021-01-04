using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace App.Domain.Models
{
    public class Brand : DomainEntity
    {
        [JsonPropertyName("code")]
        public long Code { get; set; }

        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("vehiclesModel")]
        public ICollection<VehicleModel> VehiclesModel { get; set; }
    }
}
