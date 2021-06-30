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

namespace 旅遊行程產生器
{
    public partial class CreateNwePlan_Form : Form
    {

        string DBTripPath;
        public CreateNwePlan_Form() 
        {

        }


        public CreateNwePlan_Form(string DBTripPath)
        {
            InitializeComponent();
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;

            this.DBTripPath = DBTripPath;
        }


        private void Yes_Click(object sender, EventArgs e)
        {
            if (!File.Exists(DBTripPath))
            {
                MessageBox.Show(DBTripPath);
                DataBases_Control DBC = new DataBases_Control(DBTripPath);
                DBC.DBMaker();
                string[] line_header = new string[3] { "旅遊名稱", "日期", "天數" };
                DBC.DBWriter(line_header);
                string[] line = new string[3] { textBox1.Text, dateTimePicker1.Value.ToString("yyyyMMdd"), textBox3.Text };
                DBC.DBWriter(line);
            }
            else
            {
                DataBases_Control DBC = new DataBases_Control(DBTripPath);
                string[] line = new string[3] { textBox1.Text, dateTimePicker1.Value.ToString("yyyyMMdd"), textBox3.Text };
                DBC.DBWriter(line);
            }
            this.Close();
        }
        private void Cencer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
