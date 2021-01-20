using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment3.Models
{
    [Table("teams")]
    public partial class Team
    {
        public Team()
        {
            GameAwayTeams = new HashSet<Game>();
            GameHomeTeams = new HashSet<Game>();
            People = new HashSet<Person>();
        }

        [Key]
        [Column("team_id")]
        public int TeamId { get; set; }
        [Column("team_name")]
        [StringLength(50)]
        public string TeamName { get; set; }
        [Column("jersey_colour")]
        [StringLength(50)]
        public string JerseyColour { get; set; }
        [Column("division_id")]
        public int? DivisionId { get; set; }

        [ForeignKey(nameof(DivisionId))]
        [InverseProperty("Teams")]
        public virtual Division Division { get; set; }
        [InverseProperty(nameof(Game.AwayTeam))]
        public virtual ICollection<Game> GameAwayTeams { get; set; }
        [InverseProperty(nameof(Game.HomeTeam))]
        public virtual ICollection<Game> GameHomeTeams { get; set; }
        [InverseProperty(nameof(Person.Team))]
        public virtual ICollection<Person> People { get; set; }
    }
}
