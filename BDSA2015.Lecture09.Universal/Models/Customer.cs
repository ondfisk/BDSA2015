using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BDSA2015.Lecture09.Universal.Models
{
    public class Customer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        [JsonProperty("company_name")]
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [Display(Name = "Contact Name")]
        [JsonProperty("contact_name")]
        [StringLength(30)]
        public string ContactName { get; set; }

        [JsonProperty("city")]
        [StringLength(15)]
        public string City { get; set; }

        [JsonProperty("telephone")]
        [StringLength(24)]
        public string Telephone { get; set; }
    }
}
