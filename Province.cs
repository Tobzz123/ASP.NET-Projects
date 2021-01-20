using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment3.Models
{
    [Table("provinces")]
    public partial class Province
    {
        public Province()
        {
            People = new HashSet<Person>();
        }

        [Key]
        [Column("province_id")]
        [StringLength(2)]
        public string ProvinceId { get; set; }
        [Column("province_name")]
        [StringLength(50)]
        public string ProvinceName { get; set; }

        [InverseProperty(nameof(Person.Province))]
        public virtual ICollection<Person> People { get; set; }
    }
}
