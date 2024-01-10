using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyclingRace.Model
{
    public class Signalman
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [ForeignKey("Location")]
        [Display(Name = "Location")]
        public int? LocationId { get; set; }
        public Location? Locatie { get; set; }

    }
}