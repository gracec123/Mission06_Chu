using System.ComponentModel.DataAnnotations;

namespace Mission06_Chu.Models
{
    // Collection class represents the model for the Movie Collection data
    // It is used to interact with the database and holds the properties of a movie collection item
    public class Collection
    {
        [Key]
        [Required]
        public int CollectionID { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; } = DateTime.Now.Year;

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }


        public bool? Edited { get; set; }


        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
