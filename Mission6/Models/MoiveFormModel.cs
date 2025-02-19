using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models
{
    public class MovieFormModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }


        [ForeignKey("CategoryId")]
        [Required]
        public int CategoryId { get; set; }
        public Mission06_Chadwick.Models.Category? Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; }

        public string? Director { get; set; } //Optional

   
        public string? Rating { get; set; } //Optional

        [Required]
        public bool Edited { get; set; }  

        public string? LentTo { get; set; } // Optional

        [Required]
        [Column("CopiedToPlex")]
        public string Plex { get; set; }

        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; } // Optional
    }
}

