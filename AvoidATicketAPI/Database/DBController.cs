using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DBController
    {
        public void SaveMarker(double lat, double lng)
        {
            using (var context = new AvoidATicketEntities())
            {
                Marker marker = new Marker()
                {
                    Longtitude = lng,
                    Latitude = lat
                };
                context.Entry(marker).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<Marker> RetrieveMarkerList()
        {
            using (var context = new AvoidATicketEntities())
            {
                var query = from marker in context.Markers
                            select marker;
                var markerList = query.ToList();
                return markerList;
            }
        }
    }
}
