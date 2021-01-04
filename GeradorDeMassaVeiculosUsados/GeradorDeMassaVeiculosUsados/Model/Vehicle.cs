using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Domain.Models
{
    public class Vehicle : DomainEntity
    {
        [JsonPropertyName("code")]
        public long Code { get; set; }

        [JsonPropertyName("codeProductType")]
        public long CodeProductType { get; set; }

        [JsonPropertyName("codeBrand")]//- Combo 
        public long CodeBrand { get; set; }

        [JsonPropertyName("codeModel")]//- Combo 		
        public long CodeModel { get; set; }

        [JsonPropertyName("name")]//- Combo 		
        public String Name { get; set; }

        [JsonPropertyName("serialNumber")]//- Campo texto 
        public String SerialNumber { get; set; }

        [JsonPropertyName("registerNumber")]//- Campo texto 
        public String RegisterNumber { get; set; }

        [JsonPropertyName("registrationYear")]//- Campo texto 
        public String RegistrationYear { get; set; }

        [JsonPropertyName("modelYear")]//- Campo texto 
        public String ModelYear { get; set; }

        [JsonPropertyName("lastInspection")]//- Campo texto 
        public String LastInspection { get; set; }

        [JsonPropertyName("mileage")]//- Campo texto 
        public String Mileage { get; set; }

        [JsonPropertyName("price")]//- Campo texto 
        public String Price { get; set; }

        [JsonPropertyName("previousPrice")]//- Campo texto 
        public String PreviousPrice { get; set; }

        [JsonPropertyName("grossWeight")]//- Campo texto 
        public String GrossWeight { get; set; }

        [JsonPropertyName("combinedWeight")]//- Campo texto 	
        public String CombinedWeight { get; set; }

        [JsonPropertyName("board")]//- Campo texto 
        public String Board { get; set; }

        [JsonPropertyName("otherInformation")]//- Campo texto
        public String OtherInformation { get; set; }

        [JsonPropertyName("imageGallery")]//- Campo text-are 
        public String ImageGallery { get; set; }

        [JsonPropertyName("soldVehicle")]//- (Imagens para
        public bool SoldVehicle { get; set; }

        [JsonPropertyName("deactivationType")]//- Combo	
        public String DeactivationType { get; set; }

        [JsonPropertyName("deactivationDate")]//- Label 	
        public DateTime? DeactivationDate { get; set; }

        [JsonPropertyName("codeStatus")]//- Label 		
        public long CodeStatus { get; set; }

        [JsonPropertyName("codeRecord")]//- Combo 	
        public long CodeRecord { get; set; }

        [JsonPropertyName("record")]
        public Record Record { get; set; }

        [JsonPropertyName("proposals")]
        public ICollection<VehicleProposal> Proposals { get; set; }
    }
}
