using Google.Maps.Geocoding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊行程產生器
{
    public partial class ColSetting_Form : Form
    {
        public ColSetting_Form()
        {
            InitializeComponent();
        }

        public Dictionary<(string,string), bool> dict;
        public ColSetting_Form(Dictionary<(string,string), bool> dict)
        {
            InitializeComponent();
            this.dict = dict;
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
            foreach (var control in this.Controls)
            {
                if (control is GroupBox)
                {
                    GroupBox gbox = (GroupBox)control;
                    foreach (var checkbox in gbox.Controls) 
                    {
                        CheckBox cbox = (CheckBox)checkbox;
                        //cbox.Name dict[key]
                        // no such element in squence
                        // Student ,Random ... etc 衍生型資料型別 預設可以為null
                        // 基本資料型別 & 結構(struct) 不可為null (會自帶預設值)
                        bool? result = dict.Where(x => x.Key.Item1.Equals(cbox.Name)).Select(x => x.Value).FirstOrDefault();
                        if(result!=null)
                             cbox.Checked = result.Value;
                    }
                }
            }
        }

        public void Yes_Click(object sender, EventArgs e)
        {
             foreach (var control in this.Controls)
            {
                if (control is GroupBox)
                {
                    GroupBox gbox = (GroupBox)control;
                    foreach (var checkbox in gbox.Controls) 
                    {
                        CheckBox cbox = (CheckBox)checkbox;
                        (string,string) index = dict.Where(x => x.Key.Item1.Equals(cbox.Name)).Select(x => x.Key).FirstOrDefault();
                        dict[index] = cbox.Checked;
                    }
                }
            }
            this.Close();
        }

        private void Cencer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
