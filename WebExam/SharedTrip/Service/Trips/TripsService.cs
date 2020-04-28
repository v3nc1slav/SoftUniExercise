using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Service.Trips
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext dbContext;

        public TripsService(ApplicationDbContext db)
        {
            this.dbContext = db;
        }
        public string AddTrip(TripsInputModel tripsInputModel)
        {
            var trip = new Trip()
            {
                    StartPoint = tripsInputModel.StartPoint,
                    EndPoint = tripsInputModel.EndPoint,
                    DepartureTime = tripsInputModel.DepartureTime,
                    Description = tripsInputModel.Description,
                    Seats = tripsInputModel.Seats,
                    ImagePath = tripsInputModel.ImagePath,
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();

            return trip.Id;
        }


        public List<Trip> All()
        {
            var trips = dbContext.Trips.ToList();
            return trips;
        }

        public Trip Details(string id)
        {
            var trip = dbContext.Trips.FirstOrDefault(x => x.Id == id);
            return trip;
        }
    }
}
