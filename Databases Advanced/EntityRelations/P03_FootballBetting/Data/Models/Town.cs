using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int TaemId { get; set; }
        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}
