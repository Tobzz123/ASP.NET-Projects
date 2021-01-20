using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace assignment3.Models
{
    [Table("games")]
    public partial class Game
    {
        [Key]
        [Column("game_id")]
        public int GameId { get; set; }
        [Column("game_date", TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime? GameDate { get; set; }
        [Column("field")]
        [StringLength(50)]
        [Display(Name = "Field")]
        public string Field { get; set; }
        [Column("home_team_id")]
        [Display(Name = "Home")]
        public int? HomeTeamId { get; set; }
        [Column("home_team_score")]
        [Display(Name = "Home Team Score")]
        public int? HomeTeamScore { get; set; }
        [Column("away_team_id")]
        [Display(Name = "Away")]
        public int? AwayTeamId { get; set; }
        [Column("away_team_score")]
        [Display(Name = "Away Team Score")]
        public int? AwayTeamScore { get; set; }
        [Column("referee_id")]
        public int? RefereeId { get; set; }
        [Column("game_notes")]
        [Display(Name = "Game Notes")]
        [StringLength(1000)]
        public string GameNotes { get; set; }

        [ForeignKey(nameof(AwayTeamId))]
        [InverseProperty(nameof(Team.GameAwayTeams))]
        public virtual Team AwayTeam { get; set; }
        [ForeignKey(nameof(HomeTeamId))]
        [InverseProperty(nameof(Team.GameHomeTeams))]
        public virtual Team HomeTeam { get; set; }
        [ForeignKey(nameof(RefereeId))]
        [InverseProperty(nameof(Person.Games))]
        public virtual Person Referee { get; set; }
    }
}
