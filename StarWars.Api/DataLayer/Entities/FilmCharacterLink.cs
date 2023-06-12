using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.Api.DataLayer.Entities
{
    [PrimaryKey(nameof(CharacterId), nameof(FilmId))]
    public class FilmCharacterLink : IStarWarsEntity
    {
        [Column(Order = 0)]
        public Guid CharacterId { get; set; }

        [Column(Order = 1)]
        public Guid FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        public virtual Film Film { get; set; }
    }
}
