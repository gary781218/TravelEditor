using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using 旅遊行程產生器.Model;
using GMap.NET.MapProviders;
using System.Configuration;

namespace 旅遊行程產生器
{
    public partial class Form7 : Form
    {
        private List<string> _DB_search_set = new List<string>();
        private Dictionary<string, string> _dict = new Dictionary<string, string>();
        private List<string> _result = new List<string>();
        public Form7()
        {
            InitializeComponent();
        }

        public Form7(List<string> DB_search_set)
        {
            InitializeComponent();
            string str;
            string json_path = ConfigurationManager.AppSettings["DBCountries"];
            StreamReader sr = new StreamReader(json_path, false);
            str = sr.ReadToEnd();
            sr.Close();

            string zone = "";
            int pp_count = 0;
            JavaScriptSerializer js = new JavaScriptSerializer();
            Country[] personArray = js.Deserialize<Country[]>(str);
            foreach (Country p in personArray)
            {
                pp_count = 0;
                zone = "";
                foreach (var pp in p.districts)
                {
                    if (pp_count == p.districts.Length - 1)
                    {
                        zone += pp.name;
                    }
                    else 
                    {
                        zone += pp.name + ",";
                    }
                    pp_count++;
                }
                _dict.Add(p.name.ToString(), zone);
            }

            comboBox1.Items.Add("不分");
            comboBox2.Items.Add("不分");
            comboBox3.Items.Add("不分");
            comboBox3.Items.Add("食");
            comboBox3.Items.Add("樂");
            comboBox3.Items.Add("住");
            comboBox3.Items.Add("行");
            comboBox4.Items.Add("不分");
            comboBox4.Items.Add("有");
            comboBox4.Items.Add("無");

            foreach (var x in _dict)
            {
                comboBox1.Items.Add(x.Key);
            }
            
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;

            _DB_search_set = DB_search_set;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i].ToString().Equals(_DB_search_set[0]))
                {
                    comboBox1.SelectedIndex = i;
                }
            }
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (comboBox2.Items[i].ToString().Equals(_DB_search_set[1]))
                {
                    comboBox2.SelectedIndex = i;
                }
            }
            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                if (comboBox3.Items[i].ToString().Equals(_DB_search_set[2]))
                {
                    comboBox3.SelectedIndex = i;
                }
            }
            for (int i = 0; i < comboBox4.Items.Count; i++)
            {
                if (comboBox4.Items[i].ToString().Equals(_DB_search_set[3]))
                {
                    comboBox4.SelectedIndex = i;
                }
            }

            _result.Add(comboBox1.SelectedItem.ToString());
            _result.Add(comboBox2.SelectedItem.ToString());
            _result.Add(comboBox3.SelectedItem.ToString());
            _result.Add(comboBox4.SelectedItem.ToString());

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndexChanged += ComboBox_AnySelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox_AnySelectedIndexChanged;
            comboBox3.SelectedIndexChanged += ComboBox_AnySelectedIndexChanged;
            comboBox4.SelectedIndexChanged += ComboBox_AnySelectedIndexChanged;
            
            //測試用
            //foreach (var x in _result)
            //{
            //    MessageBox.Show(x);
            //}
        }

        public List<string> Result 
        { get { return _result; } }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] temp_zone;

            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("不分");
                comboBox2.SelectedIndex = 0;

            }
            else if (comboBox1.SelectedIndex > 0)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("不分");
                temp_zone = _dict[comboBox1.SelectedItem.ToString()].Split(',');
                foreach (var x in temp_zone)
                {
                    comboBox2.Items.Add(x);
                }
            }
        }

        private void ComboBox_AnySelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbox = (ComboBox)sender;
            _result[int.Parse(cbox.Tag.ToString())-1] = cbox.SelectedItem.ToString();

            //測試用
            //MessageBox.Show("已經有改變_result了唷");
            //MessageBox.Show($"_result結果為 {_result[0]} {_result[1]} {_result[2]} {_result[3]}");
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Cencer_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
