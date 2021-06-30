using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using Google.Maps;
using Google.Maps.Geocoding;
using Google.Maps.Places;
using Google.Maps.Places.Details;
using 旅遊行程產生器.Model;

namespace 旅遊行程產生器
{
    class GoogleMapAPI
    {
        private string _keyword;
        private string _apikey;
        //textresearch搜索法
        public GoogleMapAPI(string keyword) => _keyword = keyword;
        //nearby搜索法

        public List<T> TextSearch<T>() where T : new()
        {
            List<T> result = new List<T>();
            List<int> cols_index = new List<int>();

            GoogleSigned.AssignAllServices(new GoogleSigned(_apikey));
            var request = new TextSearchRequest()
            {
                Language = "zh-tw",
                Query = _keyword
            };
            var response = new PlacesService().GetResponse(request);
            
            foreach (var x in response.Results)
            {
                T t = new T();
                var props = t.GetType().GetProperties();

                props[0].SetValue(t, x.Name);
                props[1].SetValue(t, x.Rating.ToString());
                props[2].SetValue(t, x.Geometry.Location.Latitude.ToString());
                props[3].SetValue(t, x.Geometry.Location.Longitude.ToString());
                props[4].SetValue(t, x.PlaceId);
                props[5].SetValue(t, x.FormattedAddress);

                result.Add(t);
            }
            return result;
        }

        public List<T> DetailSearch<T>() where T : new()
        {
            List<T> result = new List<T>();
            List<int> cols_index = new List<int>();

            GoogleSigned.AssignAllServices(new GoogleSigned(_apikey));
            var request_detail = new PlaceDetailsRequest() 
            {
                PlaceID = _keyword,
                Language = "zh-tw"
            };
            request_detail.PlaceID = _keyword;
            request_detail.Language = "zh-tw";
            var response_details = new PlaceDetailsService().GetResponse(request_detail);

            T t = new T();
            var props = t.GetType().GetProperties();

            props[0].SetValue(t, response_details.Result.PlaceID);
            props[1].SetValue(t, response_details.Result.FormattedAddress);
            props[2].SetValue(t, response_details.Result.Website);
            props[3].SetValue(t, response_details.Result.URL);
            props[4].SetValue(t, response_details.Result.FormattedPhoneNumber);

            result.Add(t);
            
            return result;
        }

    }
}
