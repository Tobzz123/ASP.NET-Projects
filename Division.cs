using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment3.Models
{
    [Table("divisions")]
    public partial class Division
    {
        public Division()
        {
            People = new HashSet<Person>();
            Teams = new HashSet<Team>();
        }

        [Key]
        [Column("division_id")]
        public int DivisionId { get; set; }
        [Column("division_name")]
        [StringLength(50)]
        public string DivisionName { get; set; }
        [Column("teams_made")]
        public bool? TeamsMade { get; set; }

        [InverseProperty(nameof(Person.Division))]
        public virtual ICollection<Person> People { get; set; }
        [InverseProperty(nameof(Team.Division))]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
