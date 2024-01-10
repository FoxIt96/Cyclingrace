using System.ComponentModel.DataAnnotations;

namespace CyclingRace.Model
{
    public class Location
    { 
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public IList<Signalman> signalmen { get; set; } = new List<Signalman>();


    }
}
