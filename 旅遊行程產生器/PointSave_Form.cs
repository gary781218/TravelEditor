using CefSharp.WinForms.Internals;
using Google.Maps;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊行程產生器.Model;
using System.Security.Policy;
using System.Configuration;

namespace 旅遊行程產生器
{
    //未完成
    //取出外面陣列的字串，並auto修改textbox


    public partial class PointSave_Form : Form
    {
        private string DBPath;
        private string DBRowPath;
        private string DBImagesPath;
        private string url;
        //public Dictionary<string,string> DetailResult;
        GoogleMapsApiData_TextSearch data;                        //用placeid取得的資料(店名、電話、經緯度、placeid)

        public PointSave_Form(GoogleMapsApiData_TextSearch data)
        {
            InitializeComponent();
            DBPath = ConfigurationManager.AppSettings["DBPath"];
            DBRowPath = ConfigurationManager.AppSettings["DBRowPath"];
            DBImagesPath = ConfigurationManager.AppSettings["DBImagesPath"];
            this.data = data;
            textBox1.Text = data.Name;
            textBox3.Text = "食樂住行";
            textBox4.Text = "Y or N";
            textBox5.Text = "#Tag /r/n";

            this.button2.DialogResult = DialogResult.OK;
            this.button3.DialogResult = DialogResult.Cancel;
        }

        public string NAME
        { get { return this.textBox1.Text; }}
        public string STAY
        { get { return this.textBox2.Text; }}
        public string TYPE
        { get { return this.textBox3.Text; } }
        public string VISIT
        { get { return this.textBox4.Text; } }
        public string TAG
        { get { return this.textBox5.Text; } }
        public string URL
        { get { return url; } }
        //public Dictionary<string,string> DETAILRESULT
        //{ get { return DetailResult; } }


        public void getURI() 
        {
            GoogleMapAPI gmpAPI = new GoogleMapAPI(data.PlaceID);
            List<GoogleMapsApiData_DetailSearch> APIresult = gmpAPI.DetailSearch<GoogleMapsApiData_DetailSearch>();
            url = APIresult[0].Url;
        }

        //按下確定後執行的內容
        public void Yes_Click(object sender, EventArgs e)
        {
            //將placeID傳到GoogleMapAPI，並取回detailAPI結果
            GoogleMapAPI gmpAPI = new GoogleMapAPI(data.PlaceID);
            List<GoogleMapsApiData_DetailSearch> APIresult = gmpAPI.DetailSearch<GoogleMapsApiData_DetailSearch>();

            //將路徑傳入DataBases_Control
            DataBases_Control DBC = new DataBases_Control(DBRowPath);

            //取得DB row count
            int count = DBC.DBCount + 1;

            //如果路徑不存在就建立
            DBC.DBMaker();

            //將API結果與這個page修改的資料，存到矩陣
            string[] result = {
                count.ToString(),
                NAME,
                APIresult[0].Address,
                APIresult[0].Tel,
                TYPE,
                data.Rating,
                STAY,
                data.Latitude,
                data.Longitude,
                APIresult[0].Url,
                APIresult[0].Website,
                TAG,
                data.PlaceID,
                APIresult[0].DetailPlaceID,
                VISIT,
                "N",
                DateTime.Now.ToString("yyyyMMdd")
            };

                //寫入資料庫
                string DBC_path = ConfigurationManager.AppSettings["DBPath"];
                DBC = new DataBases_Control(DBC_path);
                DBC.DBWriter(result);

                //寫入數量的資料庫
                string[] x = new string[] { count.ToString() };
                DBC = new DataBases_Control(DBRowPath);
                DBC.DBWriter_cover(x);
                this.Close();
        }

        private void Cencer_Click(object sender, EventArgs e)
        {
            //如果按取消了，就把上傳的圖片及新增的路徑刪除
            string path = DBImagesPath + NAME + "\\";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            };
            this.Close();
        }

        //textbox點擊效果
        public void clear(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            textbox.Text = "";
        }
        
        //上傳圖片的功能
        public void upload_picture(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "儲存圖片至資料庫";
            dialog.InitialDirectory = ".\\";
            dialog.Multiselect = true;
            dialog.Filter = "JPEGs(*.jpg) | *.jpg; *.jpeg";
            //dialog.Filter = 
            //    "All Image Formats (*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif)|" +
            //    "*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif|Bitmaps (*.bmp)|*.bmp|" +
            //    "GIFs (*.gif)|*.gif|JPEGs (*.jpg)|*.jpg;*.jpeg|PNGs (*.png)|*.png|" +
            //    "TIFs (*.tif)|*.tif|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                label5.Text = dialog.FileName + "已經上傳";
                string new_path = DBImagesPath + NAME + "\\";
                Console.WriteLine(new_path);
                System.IO.Directory.CreateDirectory(new_path);
                string new_filename = new_path + System.IO.Path.GetFileName(dialog.FileName) + ".jpg";
                Console.WriteLine(new_filename);
                System.IO.File.Copy(dialog.FileName, new_filename, true);

            }
        }

    }
}
