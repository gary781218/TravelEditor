using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊行程產生器.Model;

namespace 旅遊行程產生器
{
    public partial class TravelDatetimeEditor_Form : Form
    {
        List<object> userControlItems;
        List<object> userControlItems_2;

        public TravelDatetimeEditor_Form(string[] Tripdate)
        {
            InitializeComponent();
            DateTime dt = DateTime.ParseExact(Tripdate[1], "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);

            for (int i=0; i < int.Parse(Tripdate[2]); i++)
            {
                string[] dt_arr = dt.AddDays(i).ToString().Split(' ');
                comboBox1.Items.Add(dt_arr[0].Replace("/","-"));
            }

            userControlItems = new List<object>();
            userControlItems.Add(new KeyDownItem()
            {
                key = "汽車",
                value = "driving"
            });
            userControlItems.Add(new KeyDownItem()
            {
                key = "腳踏車",
                value = "bicycling"
            });
            userControlItems.Add(new KeyDownItem()
            {
                key = "大眾運輸",
                value = "transit"
            });
            userControlItems.Add(new KeyDownItem()
            {
                key = "走路",
                value = "walking"
            });

            userControl11.DataSource = userControlItems;
            this.userControl11.displaymenber = "key";
            this.userControl11.disvaluemenber = "value";

            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }

        //新增時使用
        public TravelDatetimeEditor_Form(string[] Tripdate, string DB_Item_Stay, string DB_Item_Tag)
        {
            InitializeComponent();
            DateTime dt = DateTime.ParseExact(Tripdate[1], "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);

            for (int i = 0; i < int.Parse(Tripdate[2]); i++)
            {
                string[] dt_arr = dt.AddDays(i).ToString().Split(' ');
                comboBox1.Items.Add(dt_arr[0].Replace("/", "-"));
            }
            textBox1.Text = DB_Item_Tag;
            if (DB_Item_Stay != null && !DB_Item_Stay.Trim().Equals(""))
            {
                if (Double.Parse(DB_Item_Stay) % 1 == 0)
                {
                    numericUpDown4.Value = int.Parse(DB_Item_Stay);
                }
                else
                {
                    numericUpDown4.Value = int.Parse(DB_Item_Stay.Split('.')[0]);
                    double temp = Double.Parse(DB_Item_Stay) % 1.0 * 60;
                    numericUpDown5.Value = (int)temp;
                }
            }
            else
            {
                numericUpDown4.Value = int.Parse("1");
            }
            


            userControlItems = new List<object>();
            userControlItems.Add(new KeyDownItem()
            {
                key = "汽車",
                value = "汽車"
            });
            userControlItems.Add(new KeyDownItem()
            {
                key = "機車",
                value = "機車"
            });
            userControlItems.Add(new KeyDownItem()
            {
                key = "捷運",
                value = "捷運"
            });
            userControlItems.Add(new KeyDownItem()
            {
                key = "走路",
                value = "走路"
            });


            userControlItems_2 = new List<object>();
            userControlItems_2.Add(new KeyDownItem()
            {
                key = "時間",
                value = ""
            });
            userControlItems_2.Add(new KeyDownItem()
            {
                key = "距離",
                value = ""
            });

            userControl11.DataSource = userControlItems;
            this.userControl11.displaymenber = "key";
            this.userControl11.disvaluemenber = "value";

            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
        }

        //修改時使用，故要把一堆物件傳進去
        public TravelDatetimeEditor_Form(string[] Tripdate, string Seleted_Date, string Time_Start, string Time_Duration, string Tag)
        {
            InitializeComponent();
            DateTime dt = DateTime.ParseExact(Tripdate[1], "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);

            //將所有的日期顯示在combox1，提供使用者選取
            for (int i = 0; i < int.Parse(Tripdate[2]); i++)
            {
                string[] dt_arr = dt.AddDays(i).ToString().Split(' ');
                string new_date = dt_arr[0].Replace("/", "-");
                comboBox1.Items.Add(new_date);

                if (new_date.Equals(Seleted_Date))
                {
                    comboBox1.SelectedIndex = i;
                }
            }

            //將起始時間，顯示在 numericUpDown
            numericUpDown1.Value = int.Parse(Time_Start.Split(':')[0]);
            numericUpDown2.Value = int.Parse(Time_Start.Split(':')[1]);
            numericUpDown3.Value = int.Parse(Time_Start.Split(':')[2]);

            //將停留時間換算成時分秒，顯示在 numericUpDown
            if (Time_Duration != null)
            {
                if (Double.Parse(Time_Duration) % 1 == 0)
                {
                    numericUpDown4.Value = int.Parse(Time_Duration);
                }
                else
                {
                    numericUpDown4.Value = int.Parse(Time_Duration.Split('.')[0]);
                    double temp = Double.Parse(Time_Duration) % 1.0 * 60;
                    numericUpDown5.Value = (int)temp;
                }
            }
            else
            {
                numericUpDown4.Value = int.Parse("2");
            }
            

            //將重點行程，顯示在textBox1
            textBox1.Text = Tag;

            userControlItems = new List<object>();
            userControlItems.Add(new KeyDownItem()
            {
                key = "汽車",
                value = "汽車"
            });
            userControlItems.Add(new KeyDownItem()
            {
                key = "機車",
                value = "機車"
            });
            userControlItems.Add(new KeyDownItem()
            {
                key = "捷運",
                value = "捷運"
            });
            userControlItems.Add(new KeyDownItem()
            {
                key = "走路",
                value = "走路"
            });

            
            userControl11.DataSource = userControlItems;
            
            this.userControl11.displaymenber = "key";
            this.userControl11.disvaluemenber = "value";

            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
        }
        public string DATE
        { get { return comboBox1.SelectedItem.ToString(); } }
        public string TIME_START
        { get {
                string time_string = $"{comboBox1.SelectedItem.ToString()} {numericUpDown1.Value.ToString("00")}:{numericUpDown2.Value.ToString("00")}:{numericUpDown3.Value.ToString("00")}";
                DateTime Time = Convert.ToDateTime(time_string);
                return numericUpDown1.Value.ToString("00") + ":"
                    + numericUpDown2.Value.ToString("00") + ":"
                    + numericUpDown3.Value.ToString("00");
            } }
        public string TIME_DURATION
        {
            get
            {
                double result = (double)numericUpDown4.Value + ((double)numericUpDown5.Value / 60) + ((double)numericUpDown6.Value / 3600);
                return result.ToString();
            }
        }

        public string TIME_END
        {
            get
            {
                string time_string = $"{comboBox1.SelectedItem.ToString()} {numericUpDown1.Value.ToString("00")}:{numericUpDown2.Value.ToString("00")}:{numericUpDown3.Value.ToString("00")}";
                DateTime Time = Convert.ToDateTime(time_string);
                string time_string2 = Time.AddHours((double)numericUpDown4.Value).AddMinutes((double)numericUpDown5.Value).AddSeconds((double)numericUpDown6.Value).ToString("HH:mm:ss");
                return time_string2;
            }
        }
        public string TAG 
        { 
            get
            {
                return textBox1.Text;
            } 
        }
        public string TRAFFIC
        {
            get
            {
                return userControl11.travelmode;
            }
        }

        private void Yes_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Cencer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
