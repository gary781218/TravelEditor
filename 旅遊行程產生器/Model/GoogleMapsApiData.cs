using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊行程產生器.Model
{
    public class GoogleMapsApiData_TextSearch
    {
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PlaceID { get; set; }
        public string Address { get; set; }
    }

    public class GoogleMapsApiData_DetailSearch
    {
        public string DetailPlaceID { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Url { get; set; }
        public string Tel { get; set; }
        public string Address_components { get; set; }
    }
}
