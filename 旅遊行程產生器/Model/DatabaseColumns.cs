using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊行程產生器.Model
{
    class DatabaseColumns
    {
        public DatabaseColumns() { }
        public string Database_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Type { get; set; }
        public string Rating { get; set; }
        public string Stay { get; set; }
        public string Latitude { get; set; }
        public string Lontitude { get; set; }
        public string Uri { get; set; }
        public string Website { get; set; }
        public string Tag { get; set; }
        public string Placeid { get; set; }
        public string Detaiplacid { get; set; }
        public string Delete_Status { get; set; }
        public string Visit_Status { get; set; }
        public string Create_Date { get; set; }
    }
}
