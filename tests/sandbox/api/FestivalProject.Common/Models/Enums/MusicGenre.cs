using System.ComponentModel.DataAnnotations;

namespace FestivalProject.DAL.Enums
{
    public enum MusicGenre
    {
        [Display(Name = "Rocks")]
        Rock,
        Pop,
        Metal,
        HipHop,
        Emd,
        Chill
    }
}
