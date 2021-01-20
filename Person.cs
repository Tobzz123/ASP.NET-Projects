using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment3.Models
{
    [Table("persons")]
    public partial class Person
    {
        public Person()
        {
            Games = new HashSet<Game>();
        }

        [Key]
        [Column("person_id")]
        public int PersonId { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("division_id")]
        public int? DivisionId { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("gender")]
        [StringLength(1)]
        public string Gender { get; set; }
        [Column("birth_date", TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "BirthDate")]
        public DateTime? BirthDate { get; set; }
        [Column("address_line_1")]
        [StringLength(50)]
        public string AddressLine1 { get; set; }
        [Column("address_line_2")]
        [StringLength(50)]
        public string AddressLine2 { get; set; }
        [Column("city")]
        [StringLength(50)]
        public string City { get; set; }
        [Column("province_id")]
        [StringLength(2)]
        public string ProvinceId { get; set; }
        [Column("postal_code")]
        [StringLength(7)]
        public string PostalCode { get; set; }
        [Column("phone")]
        [StringLength(20)]
        public string Phone { get; set; }
        [Column("player")]
        public bool? Player { get; set; }
        [Column("skill_level")]
        [StringLength(1)]
        public string SkillLevel { get; set; }
        [Column("team_id")]
        public int? TeamId { get; set; }
        [Column("jersey_number")]
        public int? JerseyNumber { get; set; }
        [Column("coach")]
        public bool? Coach { get; set; }
        [Column("coaching_experience")]
        [StringLength(500)]
        public string CoachingExperience { get; set; }
        [Column("referee")]
        public bool? Referee { get; set; }
        [Column("referee_experience")]
        [StringLength(500)]
        public string RefereeExperience { get; set; }
        [Column("administrator")]
        public bool? Administrator { get; set; }
        [Column("user_password")]
        [StringLength(20)]
        public string UserPassword { get; set; }

        [ForeignKey(nameof(DivisionId))]
        [InverseProperty("People")]
        public virtual Division Division { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        [InverseProperty("People")]
        public virtual Province Province { get; set; }
        [ForeignKey(nameof(SkillLevel))]
        [InverseProperty(nameof(Skill.People))]
        public virtual Skill SkillLevelNavigation { get; set; }
        [ForeignKey(nameof(TeamId))]
        [InverseProperty("People")]
        public virtual Team Team { get; set; }
        [InverseProperty(nameof(Game.Referee))]
        public virtual ICollection<Game> Games { get; set; }
    }
}
