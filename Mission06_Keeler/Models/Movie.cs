using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Keeler.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category Category { get; set; }
    
    [Required]
    public string Title { get; set; }

    [Required]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }

    [Required]
    public bool Edited  { get; set; } // whether the movie has been edited
    public string? LentTo { get; set; } // Optional: who the movie is lent to
    
    [Required]
    public bool CopiedToPlex { get; set; }
    
    [StringLength(25)]
    public string? Notes { get; set; } // Optional: short notes with a length cap
}
