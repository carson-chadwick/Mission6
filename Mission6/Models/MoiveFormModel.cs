using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class MovieFormModel
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; }  // Optional (Nullable)

        public string? LentTo { get; set; } // Optional

        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; } // Optional
    }
}

