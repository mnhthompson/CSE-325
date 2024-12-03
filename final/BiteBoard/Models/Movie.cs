using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiteBoard.Models;

public class movie
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }

    [Display(Name = "Cook Time")]
    
    [StringLength(60, MinimumLength = 3)]
    public string? rating { get; set; }

    [Display(Name = "First Made")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

   
    [Display(Name = "Cooking Steps")]
    [Required]
    [StringLength(500, MinimumLength = 3)]
    public string? Price { get; set; }    

    [Display(Name = "Ingredients")]
    [Required]
    [StringLength(500, MinimumLength = 3)]
    public string? Genre { get; set; }



}