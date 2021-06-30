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
    public partial class DatabaseEditor_Form : Form
    {
        private string aa;
        private string path;
        private List<string> data;
        string[] aa_in_temp_arr;
        public List<string> list_lv1_temp = new List<string>();

        public DatabaseEditor_Form()
        {
            InitializeComponent();
        }

        public DatabaseEditor_Form(string aa, List<string> data, string path)
        {
            InitializeComponent();
            string[] temp_arr;
            string[] DBCol = ConfigurationManager.AppSettings["DBIndex"].Split(',');
            foreach (var item in data) 
            {
                temp_arr = item.Split(',');
                if (temp_arr[Array.IndexOf(DBCol, "NAME")].Equals(aa))
                {
                    aa_in_temp_arr = temp_arr;
                    break;
                }
            }
            
            textBox1.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "NAME")];
            textBox2.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "ADDRESS")];
            textBox3.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "TEL")];
            textBox4.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "TYPE")];
            textBox5.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "RATING")];
            textBox6.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "STAY")];
            textBox7.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "LATITUDE")];
            textBox8.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "LONTITUDE")];
            textBox9.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "Visit_STATUS")];
            textBox10.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "WEBSITE")];
            textBox11.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "TAG")];

            label16.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "PLACEID")];
            label17.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "DETAILPLACEID")];
            label18.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "CREATE_DATE")];
            label19.Text = aa_in_temp_arr[Array.IndexOf(DBCol, "URL")];

            this.path = path;
            this.data = data;
            this.aa = aa;

            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            string sourceFile = ConfigurationManager.AppSettings["DBPath"];
            string destFile = ConfigurationManager.AppSettings["DBDeletePath"];

            if (File.Exists(destFile) == true) 
            {
                File.Delete(destFile);
            }
            File.Move(sourceFile, destFile);

            string[] result = new string[]
            {
                aa_in_temp_arr[Array.IndexOf(ConfigurationManager.AppSettings["DBIndex"].Split(','), "ID")],
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text,
                label19.Text,
                textBox10.Text,
                textBox11.Text,
                label16.Text,
                label17.Text,
                textBox9.Text,
                aa_in_temp_arr[Array.IndexOf(ConfigurationManager.AppSettings["DBIndex"].Split(','), "Delete_STATUS")],
                label18.Text
            };

            string DBC_path = ConfigurationManager.AppSettings["DBPath"];
            DataBases_Control DBC = new DataBases_Control(DBC_path);
            
            //如果路徑不存在就建立
            DBC.DBMaker();

            //寫入資料庫
            DBC = new DataBases_Control(DBC_path);

            DBC.DBWriter(ConfigurationManager.AppSettings["DBIndex"].Split(','));

            foreach (var line in data)
            {
                string[] temp_arr = line.Split(',');

                if (temp_arr[Array.IndexOf(ConfigurationManager.AppSettings["DBIndex"].Split(','), "NAME")].Equals(aa))
                {
                    DBC.DBWriter(result);

                    string str = "";
                    string str_temp;
                    for (int i =0;i<result.Length;i++)
                    {
                        if (i < result.Length - 1)
                        {
                            str_temp = result[i] + ",";
                            str += str_temp;
                        }
                        else 
                        {
                            str += result[i];
                        }
                    }
                    list_lv1_temp.Add(str);
                }
                else 
                {
                    DBC.DBWriter(temp_arr);
                    list_lv1_temp.Add(line);
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
