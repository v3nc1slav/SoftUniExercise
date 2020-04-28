using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class Trip
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [MinLength (2), MaxLength (6)]
        [Required]
        public int Seats { get; set; }

        [MaxLength(80)]
        [Required]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public int UserId { get; set; }

        public ICollection<UserTrip> UserTrip { get; set; } = new HashSet<UserTrip>();

        //•	Has a DepartureTime – a datetime(required) (use format: "dd.MM.yyyy HH:mm")
        public Trip()
        {
            this.Id = Guid.NewGuid().ToString();

        }

    }
}
