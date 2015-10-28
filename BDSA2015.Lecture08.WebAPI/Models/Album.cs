using System.ComponentModel.DataAnnotations;

namespace BDSA2015.Lecture08.WebAPI.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }
    }
}
