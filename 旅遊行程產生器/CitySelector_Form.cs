using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊行程產生器
{
    public partial class CitySelector_Form : Form
    {
        List<object> data;
        public CitySelector_Form()
        {
            InitializeComponent();
            data = new List<object>();
            string str;
            string json_path = ConfigurationManager.AppSettings["DBCountries"];
            StreamReader sr = new StreamReader(json_path, false);
            str = sr.ReadToEnd();
            sr.Close();


        }
    }
}
