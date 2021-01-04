using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Domain.Models
{
    public abstract class DomainEntity
    {
        public DomainEntity()
        {
            CreateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("dateUpdate")]
        public DateTime? DateUpdate { get; set; }

        [JsonPropertyName("userCode")]
        public String UserCode { get; set; } 
    }

    public interface IEntityImage 
    {
        String Path { get; set; }
    }
}
