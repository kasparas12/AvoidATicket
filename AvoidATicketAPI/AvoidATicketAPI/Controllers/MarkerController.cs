using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;

namespace AvoidATicketAPI.Controllers
{
    public class MarkerController : ApiController
    {
        // GET: api/Marker
        public IEnumerable<Marker> Get()
        {
            DBController controller = new DBController();
            return controller.RetrieveMarkerList() as IEnumerable<Marker>;
        }

        // POST: api/Marker
        public void Post([FromBody]Marker value)
        {
            DBController controller = new DBController();
            controller.SaveMarker(value.Latitude, value.Longtitude);
        }
    }
}
