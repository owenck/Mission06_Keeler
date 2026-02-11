using System.ComponentModel.DataAnnotations;

namespace Mission06_Keeler.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public string Rating { get; set; }

    public bool? Edited  { get; set; } // Optional: whether the movie has been edited
    public string? LentTo { get; set; } // Optional: who the movie is lent to

    [StringLength(25)]
    public string? Notes { get; set; } // Optional: short notes with a length cap
}
