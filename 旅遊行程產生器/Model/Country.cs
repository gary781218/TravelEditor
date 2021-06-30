using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊行程產生器.Model
{
    class Country
    {
        public string name { get; set; }
        public districts[] districts { get; set; }
    }

    class districts 
    {
        public string zip { get; set; }
        public string name { get; set; }
    }
}
