using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment3.Models
{
    [Table("skills")]
    public partial class Skill
    {
        public Skill()
        {
            People = new HashSet<Person>();
        }

        [Key]
        [Column("skill_level")]
        [StringLength(1)]
        public string SkillLevel { get; set; }
        [Column("skill_description")]
        [StringLength(50)]
        public string SkillDescription { get; set; }

        [InverseProperty(nameof(Person.SkillLevelNavigation))]
        public virtual ICollection<Person> People { get; set; }
    }
}
