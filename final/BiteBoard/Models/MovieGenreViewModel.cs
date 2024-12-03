using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BiteBoard.Models;

public class RecipeGenreViewModel
{
    public List<movie>? movies { get; set; }
    public SelectList? Genres { get; set; }
    public string? movieGenre { get; set; }
    public string? SearchString { get; set; }

    public SelectList? ReleaseDate { get; set; }
    public string? movieYear { get; set; }


}