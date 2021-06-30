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
using CefSharp;
using CefSharp.WinForms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Google.Maps;
using Google.Maps.Direction;
using Google.Maps.DistanceMatrix;
using 旅遊行程產生器.Model;

namespace 旅遊行程產生器
{
    public partial class PlanEditor_Form : Form
    {
        #region Form3 全域變數

        private string SelectedDate;              //紀錄頁面中當下被使用者選取要顯示的日期
        private string DBPath;                    //景點資料庫的路徑+csv檔名
        private string DBImagesPath;              //景點圖片存放的路徑
        private string DBTripPath;
        private string DBTripCSVPath;             //儲存專案名稱、日期、天數的.csv
        private string DBTripCSVFocus;
        private string [] DBIndex;
        //private List<string> DBIndex;

        
        string[] tagData = new string[3];         //專案名稱、日期、天數
        string[] _Trip_Date = new string[3];      //專案名稱、日期、天數
        List<string> data = new List<string>();   //從csv取出專案內資料，包含flp資料及交通路徑、時間
        ChromiumWebBrowser browser;

        #endregion

        //目前只能顯示預設的介面，可編輯旅程，無讀取的功能(!未完成:判斷path是否有檔案，如果有就將資料渲染寫入到Form3)
        public PlanEditor_Form(string[] _tagData)
        {
            InitializeComponent();

            //介面初始化
            this.label4.Text = _tagData[0];
            this.label2.Text = _tagData[1] + "出發, 共" + _tagData[2] + "天";

            //介面初始化 - 建立日期的label，供後續點選展示
            DateTime dt = DateTime.ParseExact(_tagData[1], "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            for (int i = 0; i < int.Parse(_tagData[2]); i++)
            {
                Label label = new Label().create(100, 100, 0, 0, dt.AddDays(i).ToString().Split(' ')[0]);
                label.BackColor = Color.FromArgb(220, 220, 220);
                label.Margin = new Padding(20, 0, 0, 0);
                label.MouseHover += mouse_on_date;
                label.MouseLeave += mouse_out_date;
                label.Tag = label.Text.Replace("/", "-");
                label.Click += new EventHandler(mouse_click);
                if (i == 0)
                {
                    label.BackColor = Color.FromArgb(200, 155, 0);
                    label.ForeColor = Color.White;
                    SelectedDate = label.Text.Replace("/", "-");

                    //把data加入flp，再加入flp1

                    //把點位取出來，再加入map

                    //把路線取出來，再加入map
                };
                this.flowLayoutPanel3.Controls.Add(label);
            }

            //外部參數存取至內部變數，供後續使用
            DBPath = ConfigurationManager.AppSettings["DBPath"];
            DBImagesPath = ConfigurationManager.AppSettings["DBImagesPath"];
            DBIndex = ConfigurationManager.AppSettings["DBIndex"].Split(',');
            //DBIndex = ConfigurationManager.AppSettings["DBIndex"].Split(',').ToList<string>();
            DBTripPath = ConfigurationManager.AppSettings["DBTripPath"];
            DBTripCSVPath = ConfigurationManager.AppSettings["DBTripCSVPath"];
            DBTripCSVFocus = DBTripCSVPath + _tagData[0] + "_" + _tagData[1] + "_" + _tagData[2] + "\\";
            //!!_Trip_Date是不是跟tagData一樣阿
            for (int i = 0; i < _tagData.Length; i++)
            {
                _Trip_Date[i] = _tagData[i];
            }
            this.tagData = _tagData;

            //讀取資料庫 -> list接起來 [日期,景點名稱,地址,placeid,起始時間,停留時間,結束時間,Tag]
            string path = DBTripCSVPath + _tagData[0] + "_" + _tagData[1] + "_" + _tagData[2] + "\\" + "TravelPlan.csv";

            //如果有找到，後續把資料加入頁面渲染
            if (File.Exists(path))
            {
                DataBases_Control DBC = new DataBases_Control(path);
                data = DBC.DBReader(true);
                //MessageBox.Show("有找到檔案");    //測試用
            }

            if (data.Count != 0)
            {
                string[] line_arr = new string[] { };
                foreach (var line in data)
                {
                    line_arr = line.Split(',');
                    TripDetailInfo trip_dinfo = new TripDetailInfo();
                    trip_dinfo.date = line_arr[0];
                    trip_dinfo.name = line_arr[1];
                    trip_dinfo.address = line_arr[2];
                    trip_dinfo.placeid = line_arr[3];
                    trip_dinfo.lat = line_arr[4];
                    trip_dinfo.lon = line_arr[5];
                    trip_dinfo.time_start = line_arr[6];
                    if (line_arr[7].Equals(""))
                    {
                        trip_dinfo.stay = "1";
                    }
                    else
                    {
                        trip_dinfo.stay = line_arr[7];
                    }
                    trip_dinfo.time_end = line_arr[8];
                    trip_dinfo.traffic = line_arr[9];
                    trip_dinfo.tag = line_arr[10];
                    list_trip_dinfo.Add(trip_dinfo);

                    Get_SeletedTrip(list_trip_dinfo);
                }
            }
        }

        //選取要編輯的行程日期，產生的滑鼠動畫
        private void mouse_on_date(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.FromArgb(150, 167, 0);
        }

        //選取要編輯的行程日期，產生的滑鼠動畫
        private void mouse_out_date(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Tag.Equals(SelectedDate))
            {
                label.BackColor = Color.FromArgb(200, 155, 0);
                label.ForeColor = Color.White;
            }
            else 
            {
                label.BackColor = Color.FromArgb(220, 220, 220);
                label.ForeColor = Color.Black;
            }
        }

        //選取要編輯的行程日期，產生的所有渲染
        private void mouse_click(object sender, EventArgs e)
        {
            foreach (var x in flowLayoutPanel3.Controls)
            {
                Label lb = (Label)x;
                lb.BackColor = Color.FromArgb(220, 220, 220);
                lb.ForeColor = Color.Black;
            }

            Label label = (Label)sender;
            label.BackColor = Color.FromArgb(200, 155, 0);
            label.ForeColor = Color.White;
            SelectedDate = label.Text.Replace("/", "-");

            Get_SeletedTrip(list_trip_dinfo);
        }


        #region 用Google API 加入***************************************************************************

        #region Google API加入 專用欄位 

        #endregion

        #region Google API加入 專用function 

        //以關鍵字傳入GoogleMapAPI，取回查詢結果
        public List<GoogleMapsApiData_TextSearch> Get_TextSearch()
        {
            GoogleMapAPI gmpAPI = new GoogleMapAPI(this.textBox3.Text);
            List<GoogleMapsApiData_TextSearch> result = gmpAPI.TextSearch<GoogleMapsApiData_TextSearch>();
            return result;
        }


        #endregion

        #region Google API加入 專用event

        //按下查詢後，呼叫Get_TextSearch()，並自動以flp顯示多筆結果(!日後需做重複防呆)
        private void Page1_Search_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            List<GoogleMapsApiData_TextSearch> APIresults = Get_TextSearch();
            foreach (var APIresult in APIresults)
            {
                var flp = new FlowLayoutPanel().create_row(300, 120, 12);
                //flp.Click += new EventHandler(Page1_Show_URI);
                //flp.Tag = APIresult;

                var label1 = new Label().create(300, 20, 10, 10, "店名:" + APIresult.Name);
                label1.AutoSize = true;
                var label2 = new Label().create(300, 20, 10, 30, "地址:" + APIresult.Address);
                var label3 = new Label().create(300, 20, 10, 30, "星數:" + APIresult.Rating);

                var btn1 = new Button().create(130, 30, 90, 70, "加入行程");
                btn1.Padding = new Padding(30, 0, 0, 0);
                btn1.Click += new EventHandler(Page1_Link_Form9);
                btn1.Tag = APIresult;

                var btn2 = new Button().create(130, 30, 90, 70, "顯示地圖");
                btn2.Click += new EventHandler(Page1_Show_URI);
                btn2.Tag = APIresult;

                flp.Controls.Add(label1);
                flp.Controls.Add(label2);
                flp.Controls.Add(label3);
                flp.Controls.Add(btn1);
                flp.Controls.Add(btn2);
                flowLayoutPanel2.Controls.Add(flp);
            }
        }

        //編輯單一景點內容(日期、停留時間、重點行程等)
        private void Page1_Link_Form9(object sender, EventArgs e)
        {
            //用tag的方式傳到旅遊行程編輯中，會依日期與天數自動生成ComboBox的內容
            //如果按下OK，會將f9的欄位及原本btn的Tag取出，放進TripDetailInfo.cs，再存到list_trip_dinfo
            Button button = (Button)sender;
            GoogleMapsApiData_TextSearch data = (GoogleMapsApiData_TextSearch)button.Tag;

            TravelDatetimeEditor_Form f9 = new TravelDatetimeEditor_Form(_Trip_Date);
            DialogResult f9_status = f9.ShowDialog(this);

            if (f9_status == DialogResult.OK)
            {
                MessageBox.Show("已加入完成囉");

                TripDetailInfo trip_dinfo = new TripDetailInfo();
                trip_dinfo.date = f9.DATE;
                trip_dinfo.time_start = f9.TIME_START;
                trip_dinfo.time_end = f9.TIME_END;
                trip_dinfo.name = data.Name;
                trip_dinfo.address = data.Address;
                trip_dinfo.tag = f9.TAG;
                trip_dinfo.stay = f9.TIME_DURATION;
                trip_dinfo.lon = data.Longitude;
                trip_dinfo.lat = data.Latitude;
                trip_dinfo.placeid = data.PlaceID;
                trip_dinfo.traffic = f9.TRAFFIC;
                list_trip_dinfo.Add(trip_dinfo);

            }
            Get_SeletedTrip(list_trip_dinfo);
        }
        
        //以place api查詢時，按下顯示地圖，可以看到map
        private void Page1_Show_URI(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GoogleMapsApiData_TextSearch data = (GoogleMapsApiData_TextSearch)btn.Tag;
            PointSave_Form f5 = new PointSave_Form(data);
            f5.getURI();

            browser = new ChromiumWebBrowser(f5.URL);
            browser.Name = "webBrowser1";
            browser.Dock = DockStyle.Fill;
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(this.browser);
        }



        #endregion

        #endregion

        #region 用景點庫 加入************************************************************************

        #region 景點庫加入 專用欄位
        //關鍵字textbox點擊次數
        int textBox1_click_count = 0;

        //ListView1欄位顯示設定
        Dictionary<(string, string), bool> DB_DBColumn_onoff = new Dictionary<(string, string), bool>();          //載入時存放ListView1的欄位預設顯示
        Dictionary<(string, string), bool> DB_DBColumn_onoff_user = new Dictionary<(string, string), bool>();     //經使用者調整ListView1的欄位顯示後，存在這裡
        List<string> DB_DetailSearch_setting = new List<string>() { "不分", "不分", "不分", "不分" };

        //儲存ListView1資料用，讀取一次資料庫後存到listview1_contents，供後續使用
        List<string> listview1_contents = new List<string>();          //存取Line_temp，為所有資料(須符合dict為true的欄位)
        
        //圖片用
        int PhotoShow_index = 0;                                       //圖片起始值，給上下頁使用
        String aa;                                                     //景點名稱
        List<string> photoinDir_files = new List<string>();            //存取/aa底下所有的jpg名稱


        #endregion

        #region 景點庫加入 專用funtion

        //讀取資料庫csv，並逐行以字串方式將資料存到list_lv1_temp變數中 (!未完成:函式確定)
        private void Get_All_Databases()
        {
            bool hasHeader = true;
            DataBases_Control DBC = new DataBases_Control(DBPath);
            listview1_contents = DBC.DBReader(hasHeader);
        }

        //將App.config中的listview_page2_DBshow欄位設定預設值存入DB_DBColumn_onoff(dict)
        private void Get_DBColumn_onoff()
        {
            DB_DBColumn_onoff.Clear();
            string[] listview1_col_bool = ConfigurationManager.AppSettings["listview1_col_show"].Split(',');
            foreach (var x in listview1_col_bool)
            {
                string[] x_arr = x.Split(':');
                string key_eng = x_arr[0];
                string key_chin = x_arr[1];
                bool value = bool.Parse(x_arr[2]);
                DB_DBColumn_onoff.Add((key_eng, key_chin), value);
            }
        }

        #endregion

        #region 景點庫加入 專用event

        //呼叫依照dict的bool，及判斷是否被刪除，決定要顯示的Row與Col
        private void Show_All_Databases(object sender, EventArgs e)
        {
            List<string> listview1_line_items_temp = new List<string>();

            int Index_ADDRESS = Array.IndexOf(DBIndex, "ADDRESS");
            int Index_TYPE = Array.IndexOf(DBIndex, "TYPE");
            int Index_Visit_STATUS = Array.IndexOf(DBIndex, "Visit_STATUS");
            int Index_delete_status = Array.IndexOf(DBIndex, "Delete_STATUS");
            List<string> DB_DetailSearch_setting_Covert = new List<string>();  //[縣市、區域、類別、有無去過]，皆為中文字如["台北市","不分","食","是"] 
            //把不分換為""，把是否換為YN
            foreach (var x in DB_DetailSearch_setting)
            {
                if (x.Equals("不分"))
                {
                    DB_DetailSearch_setting_Covert.Add("");
                }
                else
                {
                    if (x.Equals("有"))
                    {
                        DB_DetailSearch_setting_Covert.Add("Y");
                    }
                    else if (x.Equals("無"))
                    {
                        DB_DetailSearch_setting_Covert.Add("N");
                    }
                    else
                    {
                        DB_DetailSearch_setting_Covert.Add(x);
                    }
                }
            }

            listView_page3_DBshow.Items.Clear();
            Get_All_Databases();

            foreach (var listview1_lines in listview1_contents) //
            {
                string[] listview1_line_items_hasCondition = new string[] { };
                string[] listview1_line_items = listview1_lines.Split(',');         //每行文字串

                //測試用
                //MessageBox.Show(list);
                //MessageBox.Show("DBS0:" + DB_search_set_temp[0]);
                //MessageBox.Show("list_item[ADDRESS]:" + list_item[Index_ADDRESS]);
                //MessageBox.Show("DBS1:" + DB_search_set_temp[1]);
                //MessageBox.Show("list_item[ADDRESS]:" + list_item[Index_ADDRESS]);
                //MessageBox.Show("DBS2:" + DB_search_set_temp[2]);
                //MessageBox.Show("list_item[Index_TYPE]:" + list_item[Index_TYPE]);
                //MessageBox.Show("DBS3:" + DB_search_set_temp[3]);
                //MessageBox.Show("list_item[Index_TYPE]:" + list_item[Index_Visit_STATUS]);


                //判斷進階篩選條件
                if (listview1_line_items[Index_ADDRESS].Contains(DB_DetailSearch_setting_Covert[0])
                    && listview1_line_items[Index_ADDRESS].Contains(DB_DetailSearch_setting_Covert[1])
                    && listview1_line_items[Index_TYPE].Contains(DB_DetailSearch_setting_Covert[2])
                    && listview1_line_items[Index_Visit_STATUS].Contains(DB_DetailSearch_setting_Covert[3])
                    && listview1_line_items[Index_delete_status].Equals("N"))
                {
                    listview1_line_items_hasCondition = listview1_line_items;
                }

                //測試用
                //foreach (var x in list_item_Conditional)
                //{
                //    MessageBox.Show("經過篩選出來的line:" + x);
                //}


                //如果沒有按過查詢或顯示全部，DBColumn就沒有初始化過，所以要先確定DBColumn哪些要顯示
                if (DB_DBColumn_onoff.Count == 0 && DB_DBColumn_onoff_user.Count == 0 && listview1_line_items_hasCondition.Length > 0)
                {
                    int loop_count = 0;
                    Get_DBColumn_onoff();                      //把DBcolumn抓進dict變數

                    foreach (var DB_DBColumn_onoff_item in DB_DBColumn_onoff)
                    {
                        if (DB_DBColumn_onoff_item.Value == true)
                        {
                            listview1_line_items_temp.Add(listview1_line_items_hasCondition[loop_count]);
                        }
                        loop_count += 1;                      //另外寫的計數器，用來抓該col的資料
                    }
                    listView_page3_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
                }
                else if (DB_DBColumn_onoff.Count != 0 && DB_DBColumn_onoff_user.Count == 0 && listview1_line_items_hasCondition.Length > 0)          //如果dict有資料的，但dict_user沒資料，代表為config內訂，未修改欄位顯示
                {
                    int loop_count = 0;
                    listview1_line_items_temp.Clear();
                    foreach (var DB_DBColumn_onoff_item in DB_DBColumn_onoff)
                    {
                        if (DB_DBColumn_onoff_item.Value == true)
                        {
                            listview1_line_items_temp.Add(listview1_line_items_hasCondition[loop_count]);
                        }
                        loop_count += 1;
                    }
                    listView_page3_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
                }
                else if (DB_DBColumn_onoff_user.Count != 0 && listview1_line_items_hasCondition.Length > 0)
                {
                    int loop_count = 0;
                    listview1_line_items_temp.Clear();
                    foreach (var DB_DBColumn_onoff_item in DB_DBColumn_onoff_user)
                    {
                        if (DB_DBColumn_onoff_item.Value == true)
                        {
                            listview1_line_items_temp.Add(listview1_line_items_hasCondition[loop_count]);
                        }
                        loop_count += 1;
                    }
                    listView_page3_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
                }
                else if (listview1_line_items_hasCondition.Length == 0)
                {
                    continue;
                }
            }
        }

        //進階篩選條件，設定可從資料庫找出哪些類型的資料(如縣市、類型等)，會影響後續查詢跟全部顯示
        private void Page3_Link_Form7(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(DB_DetailSearch_setting);
            DialogResult dlresult = f7.ShowDialog(this);

            if (dlresult == DialogResult.OK)
            {
                DB_DetailSearch_setting = f7.Result;
                MessageBox.Show("已修改完成，請重新查詢或顯示全部");
            }
        }

        //textBox1的點擊特效
        private void textBox1_click(object sender, EventArgs e)
        {
            if (textBox1_click_count == 0)
            {
                tBox_page3_search.Text = "";
                textBox1_click_count += 1;
            }
        }

        //以關鍵字，在list_lv1_temp中搜尋
        private void Page3_TextSearch_Databases(object sender, EventArgs e)
        {
            List<string> listview1_line_items_temp = new List<string>();

            int Index_NAME = Array.IndexOf(DBIndex, "NAME");
            int Index_ADDRESS = Array.IndexOf(DBIndex, "ADDRESS");
            int Index_TYPE = Array.IndexOf(DBIndex, "TYPE");
            int Index_Visit_STATUS = Array.IndexOf(DBIndex, "Visit_STATUS");
            int Index_delete_status = Array.IndexOf(DBIndex, "Delete_STATUS");
            List<string> DB_DetailSearch_setting_Covert = new List<string>();  //[縣市、區域、類別、有無去過]，皆為中文字如["台北市","不分","食","是"] 
            //把不分換為""，把是否換為YN
            foreach (var x in DB_DetailSearch_setting)
            {
                if (x.Equals("不分"))
                {
                    DB_DetailSearch_setting_Covert.Add("");
                }
                else
                {
                    if (x.Equals("有"))
                    {
                        DB_DetailSearch_setting_Covert.Add("Y");
                    }
                    else if (x.Equals("無"))
                    {
                        DB_DetailSearch_setting_Covert.Add("N");
                    }
                    else
                    {
                        DB_DetailSearch_setting_Covert.Add(x);
                    }
                }
            }

            if (tBox_page3_search.Text.Equals("") || tBox_page3_search.Text.Equals("請輸入關鍵字"))
            {
                MessageBox.Show("請輸入關鍵字");
            }
            else
            {
                listView_page3_DBshow.Items.Clear();
                Get_All_Databases();

                foreach (var listview1_lines in listview1_contents)
                {
                    string[] listview1_line_items_hasCondition = new string[] { };
                    string[] listview1_line_items = listview1_lines.Split(',');         //每行文字串

                    //測試用
                    //MessageBox.Show(listview1_line_items[Index_NAME]);
                    //MessageBox.Show(tBox_SearchDB.Text);


                    //判斷進階篩選條件
                    if (listview1_line_items[Index_NAME].Contains(tBox_page3_search.Text)
                        && listview1_line_items[Index_ADDRESS].Contains(DB_DetailSearch_setting_Covert[0])
                        && listview1_line_items[Index_ADDRESS].Contains(DB_DetailSearch_setting_Covert[1])
                        && listview1_line_items[Index_TYPE].Contains(DB_DetailSearch_setting_Covert[2])
                        && listview1_line_items[Index_Visit_STATUS].Contains(DB_DetailSearch_setting_Covert[3])
                        && listview1_line_items[Index_delete_status].Equals("N"))
                    {
                        listview1_line_items_hasCondition = listview1_line_items;
                    }

                    if (DB_DBColumn_onoff.Count == 0 && DB_DBColumn_onoff_user.Count == 0 && listview1_line_items_hasCondition.Length > 0)
                    {
                        int loop_count = 0;
                        Get_DBColumn_onoff();                      //把DBcolumn抓進dict變數

                        foreach (var DB_DBColumn_onoff_item in DB_DBColumn_onoff)
                        {
                            if (DB_DBColumn_onoff_item.Value == true)
                            {
                                listview1_line_items_temp.Add(listview1_line_items_hasCondition[loop_count]);
                            }
                            loop_count += 1;                      //另外寫的計數器，用來抓該col的資料
                        }
                        listView_page3_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
                    }
                    else if (DB_DBColumn_onoff.Count != 0 && DB_DBColumn_onoff_user.Count == 0 && listview1_line_items_hasCondition.Length > 0)          //如果dict有資料的，但dict_user沒資料，代表為config內訂，未修改欄位顯示
                    {
                        int loop_count = 0;
                        listview1_line_items_temp.Clear();
                        foreach (var DB_DBColumn_onoff_item in DB_DBColumn_onoff)
                        {
                            if (DB_DBColumn_onoff_item.Value == true)
                            {
                                listview1_line_items_temp.Add(listview1_line_items_hasCondition[loop_count]);
                            }
                            loop_count += 1;
                        }
                        listView_page3_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
                    }
                    else if (DB_DBColumn_onoff_user.Count != 0 && listview1_line_items_hasCondition.Length > 0)
                    {
                        int loop_count = 0;
                        listview1_line_items_temp.Clear();
                        foreach (var DB_DBColumn_onoff_item in DB_DBColumn_onoff_user)
                        {
                            if (DB_DBColumn_onoff_item.Value == true)
                            {
                                listview1_line_items_temp.Add(listview1_line_items_hasCondition[loop_count]);
                            }
                            loop_count += 1;
                        }
                        listView_page3_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
                    }
                    else if (listview1_line_items_hasCondition.Length == 0)
                    {
                        continue;
                    }
                }
            }
        }

        //此塊功能主要目的: 當選擇了listView1上任一個名稱時，自動改變Tag內容與第一張圖片，並加上圖片上下頁功能
        private void Page3_listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView_page3_DBshow.SelectedItems.Count > 0)                                     //判斷listview有被選中項
            {
                int listView1_SelectedIndex = listView_page3_DBshow.SelectedItems[0].Index;                               //取當前選中項的index,SelectedItems[0]這必須爲0
                aa = listView_page3_DBshow.Items[listView1_SelectedIndex].SubItems[0].Text;                               //用我們剛取到的index取被選中的某一列的值從0開始

                foreach (var listview1_contents_line in listview1_contents)
                {
                    string[] listview1_contents_line_items = listview1_contents_line.Split(',');

                    if (listview1_contents_line_items[Array.IndexOf(DBIndex, "NAME")].Equals(aa))
                    {
                        //顯示tag的資訊
                        textBox2.Text = listview1_contents_line_items[Array.IndexOf(DBIndex, "TAG")];

                        if (Directory.Exists(DBImagesPath + aa))
                        {
                            photoinDir_files.Clear();
                            ImagesWork imgwork = new ImagesWork();
                            Image img = imgwork.getImage(DBImagesPath, aa, PhotoShow_index);
                            pictureBox1.Image = img;
                            foreach (var x in imgwork.list_photoinDir)
                            {
                                photoinDir_files.Add(x);
                            }

                            if (photoinDir_files.Count > 1)
                            {
                                btn_Photo_Prev.Visible = true;
                                btn_Photo_Prev.Text = "上一張";
                                btn_Photo_Prev.Enabled = false;
                                btn_Photo_Next.Visible = true;
                                btn_Photo_Next.Text = "下一張";
                                btn_Photo_Next.Enabled = true;
                                label_page3_photoinfo.Text = "現在為第1張, " + "共" + photoinDir_files.Count.ToString() + "張";
                            }
                            else if (photoinDir_files.Count == 1)
                            {
                                pictureBox1.Image = img;
                                btn_Photo_Prev.Visible = false;
                                btn_Photo_Next.Visible = false;
                                label_page3_photoinfo.Text = "現在為第1張, " + "共1張";
                            }

                        }
                        else
                        {
                            string[] img_arr = { DBImagesPath + "沒有圖片.jpg" };
                            FileStream picture_fs = new FileStream(img_arr[0], FileMode.Open, FileAccess.Read);
                            Image img = Image.FromStream(picture_fs);
                            pictureBox1.Image = img;
                            btn_Photo_Prev.Visible = false;
                            btn_Photo_Next.Visible = false;
                            label_page3_photoinfo.Text = "沒有圖片";
                        }
                        break;
                    }
                }
            }
        }

        //圖片下一頁功能
        private void Page3_PhotoShow_Next(object sender, EventArgs e)
        {
            if (PhotoShow_index < photoinDir_files.Count - 1)
            {
                PhotoShow_index++;
                ImagesWork imgwork = new ImagesWork();
                pictureBox1.Image = imgwork.getImage(DBImagesPath, aa, PhotoShow_index);
                label_page3_photoinfo.Text = "現在為第" + (PhotoShow_index + 1) + "張, 共" + photoinDir_files.Count.ToString() + "張";
                if (PhotoShow_index == photoinDir_files.Count - 1)
                {
                    btn_Photo_Next.Enabled = false;
                }
                if (PhotoShow_index > 0)
                {
                    btn_Photo_Prev.Enabled = true;
                }
            }
        }

        //圖片上一頁功能
        private void Page3_PhotoShow_Prev(object sender, EventArgs e)
        {
            if (PhotoShow_index > 0)
            {
                PhotoShow_index--;
                ImagesWork imgwork = new ImagesWork();
                pictureBox1.Image = imgwork.getImage(DBImagesPath, aa, PhotoShow_index);
                label_page3_photoinfo.Text = "現在為第" + (PhotoShow_index + 1) + "張, 共" + photoinDir_files.Count.ToString() + "張";
                if (PhotoShow_index == 0)
                {
                    btn_Photo_Prev.Enabled = false;
                }
                if (PhotoShow_index < photoinDir_files.Count)
                {
                    btn_Photo_Next.Enabled = true;
                }
            }
        }

        //編輯單一景點內容(日期、停留時間、重點行程等)，如果按下OK，呼叫Get_SeletedTrip進行頁面渲染
        private void Page3_Link_Form9(object sender, EventArgs e)
        {
            string DB_Item_Name = "";
            string DB_Item_Address = "";
            string DB_Item_Tag = "";
            string DB_Item_Lat = "";
            string DB_Item_Lon = "";
            string DB_Item_Stay = "";
            string DB_Item_PlaceId = "";
            //用tag的方式傳到旅遊行程中，以利後續儲存
            if (this.listView_page3_DBshow.SelectedItems.Count > 0)                                     //判斷listview有被選中項
            {
                int Index = listView_page3_DBshow.SelectedItems[0].Index;                               //取當前選中項的index,SelectedItems[0]這必須爲0
                aa = listView_page3_DBshow.Items[Index].SubItems[0].Text;                               //用我們剛取到的index取被選中的某一列的值從0開始
                string[] DBIndex = ConfigurationManager.AppSettings["DBIndex"].Split(',');

                foreach (var lv_items in listview1_contents)
                {
                    string[] lv_item = lv_items.Split(',');

                    if (lv_item[Array.IndexOf(DBIndex, "NAME")].Equals(aa))
                    {
                        //顯示tag的資訊
                        DB_Item_Name = lv_item[Array.IndexOf(DBIndex, "NAME")];
                        DB_Item_Address = lv_item[Array.IndexOf(DBIndex, "ADDRESS")];
                        DB_Item_Tag = lv_item[Array.IndexOf(DBIndex, "TAG")];
                        DB_Item_Lat = lv_item[Array.IndexOf(DBIndex, "LATITUDE")];
                        DB_Item_Lon = lv_item[Array.IndexOf(DBIndex, "LONTITUDE")];
                        DB_Item_Stay = lv_item[Array.IndexOf(DBIndex, "STAY")];
                        DB_Item_PlaceId = lv_item[Array.IndexOf(DBIndex, "PLACEID")];
                    }
                }
                TravelDatetimeEditor_Form f9 = new TravelDatetimeEditor_Form(_Trip_Date, DB_Item_Stay, DB_Item_Tag);
                DialogResult f9_status = f9.ShowDialog(this);

                if (f9_status == DialogResult.OK && !aa.Equals(""))
                {
                    MessageBox.Show("已加入完成囉");

                    TripDetailInfo trip_dinfo = new TripDetailInfo();
                    trip_dinfo.date = f9.DATE;
                    trip_dinfo.time_start = f9.TIME_START;
                    trip_dinfo.time_end = f9.TIME_END;
                    trip_dinfo.stay = f9.TIME_DURATION;
                    trip_dinfo.name = DB_Item_Name;
                    trip_dinfo.address = DB_Item_Address;
                    trip_dinfo.tag = DB_Item_Tag;
                    trip_dinfo.lat = DB_Item_Lat;
                    trip_dinfo.lon = DB_Item_Lon;
                    trip_dinfo.placeid = DB_Item_PlaceId;
                    trip_dinfo.traffic = f9.TRAFFIC;
                    list_trip_dinfo.Add(trip_dinfo);

                    Get_SeletedTrip(list_trip_dinfo);
                }
            }
        }

        #endregion

        #endregion

        #region 共用區************************************************************************

        #region 共用 欄位

        private List<PointLatLng> list;                                     //儲存兩個placeid 之間的路線經緯度
        List<FlowLayoutPanel> flp_temp = new List<FlowLayoutPanel>();       //存放所有加入旅程的各景點詳細資料(包含不同日期，後續會根據日期做篩選)
        List<FlowLayoutPanel> flp_triffic_temp = new List<FlowLayoutPanel>();    //存放所有加入旅程的各景點之間的交通時間(Tag為結束點起始時間)
        List<TripDetailInfo> list_trip_dinfo = new List<TripDetailInfo>();  //以list存放各個景點的詳細(日期、名稱、時間等)
        GMapOverlay markers = new GMapOverlay("markers");                   //存放gmap標示用的圖層
        GMapOverlay overlay = new GMapOverlay("direction");                  //存放路線的圖層
        string travel_mode = "driving";

        #endregion

        #region 共用 function
        #endregion

        #region 共用 event
        //刪除再次確認
        private void rm_tripitem(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否確定要刪除?", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Button button = (Button)sender;
                TripDetailInfo data = (TripDetailInfo)button.Tag;
                list_trip_dinfo.Remove(list_trip_dinfo.Where(x => x.name.Equals(data.name) && x.time_start.Equals(data.time_start)).Select(x => x).FirstOrDefault());
                flp_temp.Clear();
                Get_SeletedTrip(list_trip_dinfo);
                MessageBox.Show("已刪除");
            }
        }

        //修改已加入行程中的景點資訊(日期、停留時間、重點行程等)(!未完成)
        private void ch_tripinfo(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            TripDetailInfo data = (TripDetailInfo)button.Tag;
            TravelDatetimeEditor_Form f9 = new TravelDatetimeEditor_Form(_Trip_Date, data.date, data.time_start, data.stay, data.tag);
            DialogResult f9_status = f9.ShowDialog(this);
            if (f9_status == DialogResult.OK)
            {
                MessageBox.Show("已修改完成囉");

                list_trip_dinfo.Remove(list_trip_dinfo.Where(x => x.name.Equals(data.name)&& x.time_start.Equals(data.time_start)).Select(x => x).FirstOrDefault());
                TripDetailInfo trip_dinfo = new TripDetailInfo();
                trip_dinfo.date = f9.DATE;
                trip_dinfo.time_start = f9.TIME_START;
                trip_dinfo.time_end = f9.TIME_END;
                trip_dinfo.name = data.name;
                trip_dinfo.address = data.address;
                trip_dinfo.tag = f9.TAG;
                trip_dinfo.stay = f9.TIME_DURATION;
                trip_dinfo.lon = data.lon;
                trip_dinfo.lat = data.lat;
                trip_dinfo.placeid = data.placeid;
                trip_dinfo.traffic = f9.TRAFFIC;
                list_trip_dinfo.Add(trip_dinfo);
            }
            flp_temp.Clear();
            Get_SeletedTrip(list_trip_dinfo);
        }

        //gmap起始設定值 (!未完成自動zoom in 的功能)
        private void gMapControl2_Load_1(object sender, EventArgs e)
        {
            this.gMapControl1.MaxZoom = 20;
            this.gMapControl1.Zoom = 7;
            this.gMapControl1.MapProvider = GoogleMapProvider.Instance; // 設置地圖源
            this.gMapControl1.Position = new GMap.NET.PointLatLng(24, 120.8);
            this.gMapControl1.DragButton = MouseButtons.Left;
            this.gMapControl1.ShowCenter = false;
            //this.gMapControl1.OnMarkerClick += gMapControl1_OnMarkerClick;
        }

        //以list_trip_dinfo跑迴圈，與SelectedDate比對判斷，相同的話就將旅程的flp及gmap紅點渲染出來
        private void Get_SeletedTrip(List<TripDetailInfo> list_trip_dinfo)
        {
            List<string> list_placeid = new List<string>();
            string[] triffic_data;
            List<string> list_triffic = new List<string>();

            overlay.Clear();
            flp_temp.Clear();
            flowLayoutPanel1.Controls.Clear();
            markers.Markers.Clear();

            //抓出每一個flp內的資料
            for (int i = 0; i < list_trip_dinfo.Count; i++)
            {
                if (list_trip_dinfo[i].date.Equals(SelectedDate))
                {
                    //新增地圖紅點至Markers
                    GMapMarker marker = new GMarkerGoogle(new PointLatLng(double.Parse(list_trip_dinfo[i].lat), double.Parse(list_trip_dinfo[i].lon)), GMarkerGoogleType.red_dot);
                    marker.ToolTipText = "店名: " + list_trip_dinfo[i].name + "\r\n"
                        + "地址: " + list_trip_dinfo[i].address + "\r\n"
                        + "行程重點: " + list_trip_dinfo[i].tag;
                    //增加marker游標動態
                    marker.ToolTip.Fill = new SolidBrush(Color.FromArgb(100, Color.Black));
                    marker.ToolTip.Foreground = Brushes.White;
                    marker.ToolTip.TextPadding = new Size(20, 20);
                    markers.Markers.Add(marker);

                    //動態建立行程flp
                    var flp = new FlowLayoutPanel().create_row(flowLayoutPanel1.Width, 200, 12);
                    flp.Margin = new Padding(0, 0, 0, 30);
                    flp.BackColor = Color.FromArgb(216, 160, 241);
                    flp.Tag = list_trip_dinfo[i];

                    var label1 = new Label().create(500, 20, 10, 10, "日期: " + list_trip_dinfo[i].date);
                    var label2 = new Label().create(500, 20, 10, 10, "預計到達時間: " + list_trip_dinfo[i].time_start);
                    var label3 = new Label().create(500, 20, 10, 10, "預計結束時間: " + list_trip_dinfo[i].time_end);
                    var label4 = new Label().create(500, 20, 10, 10, " ");
                    var label5 = new Label().create(500, 20, 10, 10, "店名: " + list_trip_dinfo[i].name);
                    var label6 = new Label().create(500, 20, 10, 10, "地址: " + list_trip_dinfo[i].address);
                    var label7 = new Label().create(500, 20, 10, 10, "行程重點: " + list_trip_dinfo[i].tag);
                    var label8 = new Label().create(500, 20, 10, 10, "交通模式:" + list_trip_dinfo[i].traffic);
                    label8.Visible = false;
                    label3.AutoSize = true;


                    var btn1 = new Button().create(100, 30, 10, 70, "修改行程");
                    btn1.Tag = list_trip_dinfo[i];
                    btn1.Click += new EventHandler(ch_tripinfo);
                    var btn2 = new Button().create(100, 30, 10, 70, "取消行程");
                    btn2.Tag = list_trip_dinfo[i];
                    btn2.Click += new EventHandler(rm_tripitem);

                    //btn2.Padding = new Padding(200, 0, 0, 0);
                    //btn2.Click += new EventHandler(Page3_Remove_tripitem);

                    flp.Controls.Add(label1);
                    flp.Controls.Add(label2);
                    flp.Controls.Add(label3);
                    flp.Controls.Add(label4);
                    flp.Controls.Add(label5);
                    flp.Controls.Add(label6);
                    flp.Controls.Add(label7);
                    flp.Controls.Add(label8);
                    flp.Controls.Add(btn1);
                    flp.Controls.Add(btn2);
                    
                    flp_temp.Add(flp);
                }
            }

            //渲染至頁面
            //****將Markers畫到gmap
            this.gMapControl1.Overlays.Clear();
            this.gMapControl1.Overlays.Add(markers);
            this.gMapControl1.Zoom++;
            //****將flp將入flp1
            //MessageBox.Show($"flp_temp.Count={flp_temp.Count}");
            if (flp_temp.Count > 0)
            {
                //將原本依序加入的行程，重新以時間排序
                var flp_temp_Order = flp_temp.OrderBy (x => x.Controls[1].Text).ToArray();
                
                //若第二筆起始時間<第一筆結束時間，顯示紅色
                string[] time_first_end;
                string[] time_second_start;
                string[] time_first_end_arr;
                string[] time_second_start_arr;

                for (int i =0; i < flp_temp_Order.Length;i++)
                {
                    if (i == 0)
                    {
                        flowLayoutPanel1.Controls.Add(flp_temp_Order[i]);
                    }
                    else
                    {
                        //測試用
                        //MessageBox.Show(flp_temp_Order[i - 1].Controls[1].Text);
                        //MessageBox.Show(flp_temp_Order[i].Controls[2].Text);

                        //取得兩點的placeid
                        TripDetailInfo tag_first = (TripDetailInfo)flp_temp_Order[i - 1].Tag;
                        TripDetailInfo tag_second = (TripDetailInfo)flp_temp_Order[i].Tag;
                       
                        travel_mode = "driving";
                        //MessageBox.Show(flp_temp_Order[i - 1].Controls[7].Text.Split(':')[1]);
                        //取得交通方式
                        if (flp_temp_Order[i - 1].Controls[7].Text.Split(':')[1].Equals("腳踏車"))
                        {
                            travel_mode = "bicycling";
                            //MessageBox.Show("選用腳踏車");
                        }
                        else if (flp_temp_Order[i - 1].Controls[7].Text.Split(':')[1].Equals("大眾運輸"))
                        {
                            travel_mode = "transit";
                            //MessageBox.Show("選用大眾交通");
                        }
                        else if (flp_temp_Order[i - 1].Controls[7].Text.Split(':')[1].Equals("走路"))
                        {
                            travel_mode = "walking";
                            //MessageBox.Show("選用走路");
                        }
                        else
                        {
                            travel_mode = "driving";
                            //MessageBox.Show("選用開車");
                        }

                        //取得交通時間
                        triffic_data = getDistanceMatrix(tag_first.placeid, tag_second.placeid, travel_mode);
                        string[] triffic_time_arr = triffic_data[1].Split(' ');

                        #region
                        ////取出上一筆label字串(結束時間)與下一筆label字串(開始時間)的整個array
                        time_first_end = flp_temp_Order[i-1].Controls[2].Text.Split(':');
                        time_second_start = flp_temp_Order[i].Controls[1].Text.Split(':');

                        //1將日期與時間組合成固定格式的字串
                        string date = DateTime.ParseExact(tagData[1], "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");                        //string date = DateTime.Now.ToString("yyyy-MM-dd");
                        string datetime_first_end = $"{date} {time_first_end[1]}:{time_first_end[2]}:{time_first_end[3]}";
                        string datetime_second_start = $"{date} {time_second_start[1]}:{time_second_start[2]}:{time_second_start[3]}";
                        //MessageBox.Show(datetime_first_end);
                        //MessageBox.Show(datetime_second_start);

                        //將字串轉為dt
                        DateTime fDate = Convert.ToDateTime(datetime_first_end);
                        DateTime sDate = Convert.ToDateTime(datetime_second_start);

                        //2加上時間 (!這裡有問題)
                        if (triffic_data[1].Split(' ').Contains("小時"))
                        {
                            fDate = fDate.AddHours(int.Parse(triffic_time_arr[0])).AddMinutes(int.Parse(triffic_time_arr[2]));
                            //MessageBox.Show($"交通時間:{triffic_time_arr[0]} {triffic_time_arr[1]} {triffic_time_arr[2]} {triffic_time_arr[3]}");
                        }
                        else if (triffic_data[1].Split(' ').Contains("分鐘"))
                        {
                            fDate = fDate.AddMinutes(int.Parse(triffic_time_arr[0]));
                            //MessageBox.Show($"交通時間:{triffic_time_arr[0]} {triffic_time_arr[1]}");
                        }    

                        //MessageBox.Show($"fDate加上交通時間變成:{fDate.ToString("hh:mm:ss")}");
                        //MessageBox.Show($"eDate:{sDate.ToString("hh:mm:ss")}");
                        
                        //轉回字串
                        time_first_end_arr = fDate.ToString("hh:mm:ss").Split(':');
                        time_second_start_arr = sDate.ToString("hh:mm:ss").Split(':');


                        //判斷小時是否相同，如果大於就沒問題，小於直接給紅字，等於繼續判斷分跟秒 (!有點問題)
                        if (int.Parse(time_second_start_arr[0]) > int.Parse(time_first_end_arr[0]))
                        {
                            //MessageBox.Show("後小時 > 前小時");
                        }
                        else if (int.Parse(time_second_start_arr[0]) < int.Parse(time_first_end_arr[0]))
                        {
                            //MessageBox.Show("後小時 < 前小時，要變紅");
                            flp_temp_Order[i].Controls[1].ForeColor = Color.Red;
                        }
                        else 
                        {
                            //MessageBox.Show(time_second_start_arr[1] + ", " + time_first_end_arr[1]);
                            if (int.Parse(time_second_start_arr[1]) > int.Parse(time_first_end_arr[1]))
                            {
                                //MessageBox.Show("後小時 = 前小時，後分鐘 > 前分鐘");
                            }
                            else if (int.Parse(time_second_start_arr[1]) < int.Parse(time_first_end_arr[1]))
                            {
                                //MessageBox.Show("後小時 = 前小時，後分鐘 < 前分鐘，要變紅");
                                flp_temp_Order[i].Controls[1].ForeColor = Color.Red;
                            }
                            else
                            {
                                if (int.Parse(time_second_start_arr[2]) >= int.Parse(time_first_end_arr[2]))
                                {
                                    //MessageBox.Show("後小時 = 前小時，後分鐘 = 前分鐘，後秒數 >= 前秒數");
                                }
                                else if (int.Parse(time_second_start_arr[2]) < int.Parse(time_first_end_arr[2]))
                                {
                                    //MessageBox.Show("後小時 = 前小時，後分鐘 = 前分鐘，後秒數 < 前秒數，要變紅");
                                    flp_temp_Order[i].Controls[1].ForeColor = Color.Red;
                                }
                            }
                        }
                        #endregion
                        //渲染距離與交通時間到頁面上
                        var label = new Label().create(flowLayoutPanel1.Width, 20, 10, 10, $"交通工具:{flp_temp_Order[i - 1].Controls[7].Text.Split(':')[1]}, 距離:{triffic_data[0]}, 交通時間:{triffic_data[1]}");
                        label.Margin = new Padding(0, 0, 0, 20);
                        label.BackColor = Color.FromArgb(240, 200, 0);

                        flowLayoutPanel1.Controls.Add(label);
                        flowLayoutPanel1.Controls.Add(flp_temp_Order[i]);
                        
                        getDirection(tag_first.placeid, tag_second.placeid, travel_mode);
                    }
                }
            }
        }

        //marker游標動畫
        //private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        //{
        //    MessageBox.Show(String.Format("Marker：{0} 被點了。", item.ToolTipText));
        //}

        //取得兩點之間的路線
        private void getDirection(string _Origin, string _Destination, string _TravelMode)
        {
            string apikey = ConfigurationManager.AppSettings["GMapAPIKey"];
            GoogleSigned.AssignAllServices(new GoogleSigned(apikey));

            var request = new DirectionRequest();
            request.Origin = "place_id:" + _Origin;
            request.Destination = "place_id:" + _Destination;

            if (_TravelMode.Equals("bicycling"))
            {
                request.Mode = TravelMode.bicycling;
            }
            else if (_TravelMode.Equals("transit"))
            {
                request.Mode = TravelMode.transit;
            }
            else if (_TravelMode.Equals("walking"))
            {
                request.Mode = TravelMode.walking;
            }
            else
            {
                request.Mode = TravelMode.driving;
            }

            request.Language = "zh-tw";
            //request.Optimize = true;
            request.Alternatives = false;

            var response = new DirectionService().GetResponse(request);
            DirectionStep[] steps = response.Routes[0].Legs[0].Steps;

            list = new List<PointLatLng>();

            int route_count = 0;
            //overlay.Clear();
            //foreach (var step in steps)
            foreach (var route_line in response.Routes)
            {
                if (route_count == 0)
                {
                    GMapRoute route = new GMapRoute(decodePolyline(route_line.OverviewPolyline.Points), "route");
                    route.Stroke.Width = 2;
                    route.Stroke.Color = Color.Red;
                    Console.WriteLine($"route.Distance={route.Distance}");

                    overlay.Routes.Add(route);

                    gMapControl1.Overlays.Add(overlay);
                    gMapControl1.ZoomAndCenterRoute(route);
                }
                route_count++;
                ////list_GmapRoute.Add(route);
            }
        }

        //處理並逆向解密route各彎曲的點
        public List<PointLatLng> decodePolyline(String poly)
        {
            int len = poly.Length;
            int index = 0;
            int lat = 0;
            int lng = 0;
            List<PointLatLng> decoded = new List<PointLatLng>();

            while (index < len)
            {
                int b;
                int shift = 0;
                int result = 0;
                do
                {
                    b = poly.ToCharArray()[index++] - 63;
                    result |= (b & 0x1f) << shift;
                    shift += 5;
                } while (b >= 0x20);
                int dlat = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
                lat += dlat;

                shift = 0;
                result = 0;
                do
                {
                    b = poly.ToCharArray()[index++] - 63;
                    result |= (b & 0x1f) << shift;
                    shift += 5;
                } while (b >= 0x20);
                int dlng = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
                lng += dlng;

                decoded.Add(new PointLatLng(lat / 1E5, lng / 1E5));
            }
            return decoded;
        }

        //取得兩點之間的距離與交通時間
        private string[] getDistanceMatrix(string _Origin, string _Destination, string _Travel_Mode)
        {
            string apikey = ConfigurationManager.AppSettings["GMapAPIKey"];

            GoogleSigned.AssignAllServices(new GoogleSigned(apikey));
            var request = new DistanceMatrixRequest();
            //MessageBox.Show("place_id:" + _Origin);
            request.AddOrigin(new Google.Maps.Location("place_id:" + _Origin));
            request.AddDestination(new Google.Maps.Location("place_id:" + _Destination));
            request.Language = "zh-tw";

            if (_Travel_Mode.Equals("bicycling")) 
            {
                //MessageBox.Show($"getDistanceMatrix選到bicycling");
                request.Mode = TravelMode.bicycling; 
            }
            else if (_Travel_Mode.Equals("transit"))
            {
                MessageBox.Show($"getDistanceMatrix選到transit");
                request.Mode = TravelMode.transit; 
            }
            else if (_Travel_Mode.Equals("walking")) 
            {
                MessageBox.Show($"getDistanceMatrix選到walking");
                request.Mode = TravelMode.walking; 
            }
            else 
            {
                //MessageBox.Show($"getDistanceMatrix選到driving");
                request.Mode = TravelMode.driving;
            };

            var response = new DistanceMatrixService().GetResponse(request);
            //MessageBox.Show(response.Status.ToString());
            //MessageBox.Show(response.Rows[0].Elements.Length.ToString());
            //MessageBox.Show(response.Rows[0].Elements[0].distance.Text);

            string[] result = new string[] { response.Rows[0].Elements[0].distance.Text, response.Rows[0].Elements[0].duration.Text};
            return result;
        }

        //gmap Double click後會放大
        private void gMapControl2_click(object sender, EventArgs e)
        {
            this.gMapControl1.Zoom = this.gMapControl1.Zoom + 1;
        }

        //分別儲存(1)旅程內容、(2)gmap點可用(1)的placeid、(3)交通路線、(4)交通時間 
        private void Travel_Save_Click(object sender, EventArgs e)
        {
            //儲存旅程內容
            List<string> data = new List<string>();

            string DBTripCSVPath = ConfigurationManager.AppSettings["DBTripCSVPath"];
            string path = DBTripCSVPath + tagData[0] + "_" + tagData[1] + "_" + tagData[2] + "\\" + "TravelPlan.csv";
            MessageBox.Show(path);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            FileStream fs = new FileStream(path, FileMode.Create);
            fs.Close();
            DataBases_Control DBC = new DataBases_Control(path);

            string[] header = new string[] { "日期","景點名稱","地址","placeid","緯度","經度","起始時間","停留時間","結束時間","交通方式","Tag"};
            DBC.DBWriter(header);
            for (int i = 0; i < this.list_trip_dinfo.Count; i++)
            {
                data.Clear();
                data.Add(this.list_trip_dinfo[i].date);
                data.Add(this.list_trip_dinfo[i].name);
                data.Add(this.list_trip_dinfo[i].address);
                data.Add(this.list_trip_dinfo[i].placeid);
                data.Add(this.list_trip_dinfo[i].lat);
                data.Add(this.list_trip_dinfo[i].lon);
                data.Add(this.list_trip_dinfo[i].time_start);
                data.Add(this.list_trip_dinfo[i].stay);
                data.Add(this.list_trip_dinfo[i].time_end);
                data.Add(this.list_trip_dinfo[i].traffic);
                data.Add(this.list_trip_dinfo[i].tag==null?"":this.list_trip_dinfo[i].tag);

                DBC.DBWriter(data.ToArray());
            }
        }

        #endregion

        #endregion
    }
}
