using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Service.Trips
{
    public interface ITripsService
    {
        string AddTrip(TripsInputModel tripsInputModel);

        Trip Details(string id);

        List<Trip> All();
    }
}
