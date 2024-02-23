using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Chu.Models
{
    // Collection class represents the model for the Movie Collection data
    // It is used to interact with the database and holds the properties of a movie collection item
    public class Collection
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Categories? Category{ get; set; }

        [Required (ErrorMessage ="Please fill out the Title")]
        [StringLength(100)] // Assuming a max length for the title
        public string Title { get; set; }

        [Required (ErrorMessage = "Please fill out Year")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be after 1888")]
        public int Year { get; set; } = DateTime.Now.Year;

   
        [StringLength(100)] // Assuming a max length for the director's name
        public string? Director { get; set; }

        //[Required (ErrorMessage = "Please fill out Rating")]
        public string? Rating { get; set; }

        [Required (ErrorMessage = "Please fill out CopiedToPlex")]
        public bool CopiedToPlex { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }


    }
}
