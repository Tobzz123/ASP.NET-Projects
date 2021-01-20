using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment3.Models
{
    
    public partial class Player
    {
        [Key]
        [Column("player_id")]
        public int PlayerId { get; set; }
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
        [Column("skill_level")]
        [StringLength(1)]
        public string SkillLevel { get; set; }
        [Column("team_id")]
        public int? TeamId { get; set; }
        [Column("jersey_number")]
        public int? JerseyNumber { get; set; }
        [Column("user_password")]
        [StringLength(20)]
        public string UserPassword { get; set; }
    }
}
