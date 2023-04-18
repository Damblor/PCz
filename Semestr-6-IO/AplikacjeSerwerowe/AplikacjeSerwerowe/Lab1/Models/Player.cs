using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }

        //Sql database foregin keys
        public int? TeamId { get; set; }
        public virtual Team? Team { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }
    }
}
