using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public string LogoUrl { get; set; }

        [MaxLength(3)]
        [Required]
        public string Initials { get; set; }

        [Required]
        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        public  int HomeGamesId { get; set; }
        public ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();

        public int AwayGamesId { get; set; }
        public ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();

        public int PlayerId { get; set; }
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

    }
}
