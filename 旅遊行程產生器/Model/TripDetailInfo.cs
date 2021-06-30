using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊行程產生器.Model
{
    class TripDetailInfo
    {
        public string date { get; set; }
        public string time_start { get; set; }
        public string time_end { get; set; }
        public string name { get; set; }
        public string placeid { get; set; }
        public string address { get; set; }
        public string lon { get; set; }
        public string lat { get; set; }
        public string stay { get; set; }
        public string tag { get; set; }
        public string traffic { get; set; }
    }
}
