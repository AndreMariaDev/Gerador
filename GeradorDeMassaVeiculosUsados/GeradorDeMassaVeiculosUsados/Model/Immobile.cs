using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace App.Domain.Models
{
    public class Immobile : DomainEntity
    {
        [JsonPropertyName("code")]
        public long Code { get; set; }

        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("codeProductType")]//- Campo texto 
        public long CodeProductType { get; set; }

        [JsonPropertyName("registrationNumber")]//- Campo texto 
        public String RegistrationNumber { get; set; }

        [JsonPropertyName("registrationYear")]//- Campo texto 
        public String RegistrationYear { get; set; }

        [JsonPropertyName("price")]//- Campo texto 
        public String Price { get; set; }

        [JsonPropertyName("otherInformation")]//- Campo text-are 
        public String OtherInformation { get; set; }

        [JsonPropertyName("imageGallery")]//- (Imagens para
        public String ImageGallery { get; set; }

        [JsonPropertyName("codeStatus")]//- Combo 
        public long CodeStatus { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("codeTypeImmoble")]
        public long CodeTypeImmoble { get; set; }

        [JsonPropertyName("soldImmobile")]//- Combo	
        public bool SoldImmobile { get; set; }

        [JsonPropertyName("deactivationType")]//- Label 	
        public String DeactivationType { get; set; }

        [JsonPropertyName("deactivationDate")]//- Label 
        public DateTime? DeactivationDate { get; set; }

        [JsonPropertyName("proposals")]//- Label
        public ICollection<ImmobileProposal> Proposals { get; set; }

    }
}
