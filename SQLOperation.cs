using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataService
{
    public class SQLOperation
    {
        // public static string Connectionstring = "Data Source=.;Initial Catalog=EventManager;User ID=sa;Password=kensindy;"; //TrustServerCertificate=true;
        public List<trip> GetTrips()
        {
            List<trip> trips = new List<trip>();
            ItineraryEntities ie = new ItineraryEntities();
            trips= ie.trip.ToList();
            return trips;
        }

        public bool DeleteTripRepo(int tripId)
        {
            ItineraryEntities ie = new ItineraryEntities();
            var trip = ie.trip.Where(x => x.TripID == tripId).FirstOrDefault();
            if (trip != null)
            {
                ie.trip.Remove(trip);
                ie.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
