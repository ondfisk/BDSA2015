using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDSA2015.Lecture08.WebApi.Models
{
    public class Customer
    {
        [Column("CustomerID")]
        [JsonProperty("id")]
        [Key]
        [Required]
        [StringLength(5, MinimumLength =5)]
        public string Id { get; set; }

        [Display(Name = "Company Name")]
        [JsonProperty("company_name")]
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [Display(Name = "Contact Name")]
        [JsonProperty("contact_name")]
        [StringLength(30)]
        public string ContactName { get; set; }

        [Display(Name = "Contact Title")]
        [JsonProperty("contact_title")]
        [StringLength(30)]
        public string ContactTitle { get; set; }

        [JsonProperty("address")]
        [StringLength(60)]
        public string Address { get; set; }

        [JsonProperty("city")]
        [StringLength(15)]
        public string City { get; set; }

        [JsonProperty("region")]
        [StringLength(15)]
        public string Region { get; set; }

        [Display(Name = "Postal Code")]
        [JsonProperty("postal_code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [JsonProperty("country")]
        [StringLength(15)]
        public string Country { get; set; }

        [JsonProperty("phone")]
        [StringLength(24)]
        public string Phone { get; set; }

        [JsonProperty("fax")]
        [StringLength(24)]
        public string Fax { get; set; }
    }
}
