using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public int PrimaryKitTeamsId { get; set; }
        public ICollection<Team> PrimaryKitTeams { get; set; } = new HashSet<Team>();
        public int SecondaryKitTeamsId { get; set; }
        public ICollection<Team> SecondaryKitTeams { get; set; } = new HashSet<Team>();
    }
}
