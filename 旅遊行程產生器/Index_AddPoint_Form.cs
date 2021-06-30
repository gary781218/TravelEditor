using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Google.Maps;
using Google.Maps.Geocoding;
using Google.Maps.Places;
using Google.Maps.Places.Details;
using 旅遊行程產生器.Model;

namespace 旅遊行程產生器
{
    public partial class Form_Index : Form
    {
        private string DBPath;
        private string DBRowPath;
        private string DBImagesPath;
        private string DBTripPath;
        private string DBTripCSVPath;
        private string[] DBIndex;
        private string[] listview1_col_bool;
        private List<string> DBData = new List<string>();

        ChromiumWebBrowser browser;

        public Form_Index()
        {
            InitializeComponent();
            DBPath = ConfigurationManager.AppSettings["DBPath"];
            DBRowPath = ConfigurationManager.AppSettings["DBRowPath"];
            DBImagesPath = ConfigurationManager.AppSettings["DBImagesPath"];
            DBIndex = ConfigurationManager.AppSettings["DBIndex"].Split(',');
            DBTripPath = ConfigurationManager.AppSettings["DBTripPath"];
            DBTripCSVPath = ConfigurationManager.AppSettings["DBTripCSVPath"];
            listview1_col_bool = ConfigurationManager.AppSettings["listview1_col_show"].Split(',');           //listview1欄位顯示預設值
            Cef.Initialize(new CefSettings());
        }

        #region Page1功能塊***************************************************************************

        #region Page1 專用欄位
        #endregion

        #region Page1 專用function

        //以關鍵字，傳入GoogleMapAPI，取回API結果
        public List<GoogleMapsApiData_TextSearch> Get_TextSearch()
        {
            GoogleMapAPI gmpAPI = new GoogleMapAPI(this.tbox_page1_search.Text);
            List<GoogleMapsApiData_TextSearch> result = gmpAPI.TextSearch<GoogleMapsApiData_TextSearch>();
            return result;
        }

        #endregion

        #region Page1 專用event

        //按下查詢後，執行Get_TextSearch，並自動以flp顯示多筆結果(日後需做DB重複防呆)
        private void Page1_Search_Click(object sender, EventArgs e)
        {
            DataBases_Control DBC = new DataBases_Control(DBPath);
            DBData = DBC.DBReader(true);

            flp_page1_result.Controls.Clear();
            List<GoogleMapsApiData_TextSearch> APIresults = Get_TextSearch();
            foreach (var APIresult in APIresults)
            {
                var flp = new FlowLayoutPanel().create_row(500, 130, 12);
                flp.Margin = new Padding(55, 25, 55, 0);
                flp.AutoSize = true;
                flp.Tag = APIresult;

                var label1 = new Label().create(300, 20, 10, 10, "店名:" + APIresult.Name);
                label1.AutoSize = true;
                var label2 = new Label().create(300, 20, 10, 10, "地址:" + APIresult.Address);
                var label3 = new Label().create(300, 20, 10, 10, "星數:" + APIresult.Rating);
                var btn1 = new Button().create(130, 30, 90, 70, "加入景點庫");
                btn1.Margin = new Padding(15, 15, 0, 0);
                btn1.Click += new EventHandler(Page1_Link_Form5);
                btn1.Tag = APIresult;
                var btn2 = new Button().create(130, 30, 90, 70, "顯示地圖");
                btn2.Margin = new Padding(15, 15, 0, 0);
                btn2.Click += new EventHandler(Page1_Show_URI);
                btn2.Tag = APIresult;

                foreach (var DBData_line in DBData)
                {
                    if (DBData_line.Split(',')[12].Equals(APIresult.PlaceID))
                    {
                        btn1.Enabled = false;
                        btn1.Text = "已存至資料庫";
                    }
                }

                flp.Controls.Add(label1);
                flp.Controls.Add(label2);
                flp.Controls.Add(label3);
                flp.Controls.Add(btn1);
                flp.Controls.Add(btn2);
                flp_page1_result.Controls.Add(flp);
            }
        }

        //從結果flp連至form5，調整部分資訊，並在form5的程式碼中執行「存資料到DB」，回傳status為true，則修改前端畫面
        private void Page1_Link_Form5(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GoogleMapsApiData_TextSearch data = (GoogleMapsApiData_TextSearch)button.Tag;
            PointSave_Form f5 = new PointSave_Form(data);
            DialogResult result = f5.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                button.Enabled = false;
                button.Text = "已存至資料庫";
            }
        }

        //以place api查詢時，按下顯示地圖，可以看到map
        private void Page1_Show_URI(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GoogleMapsApiData_TextSearch data = (GoogleMapsApiData_TextSearch)btn.Tag;
            PointSave_Form f5 = new PointSave_Form(data);

            f5.getURI();

            browser = new ChromiumWebBrowser(f5.URL)
            {
                Name = "webBrowser1",
                Dock = DockStyle.Fill
            };
            browser.Name = "webBrowser1";
            browser.Dock = DockStyle.Fill;
            this.gbox_page1_cef.Controls.Clear();
            this.gbox_page1_cef.Controls.Add(this.browser);
        }

        #endregion

        #endregion


        #region Page2功能塊***************************************************************************

        #region Page2 專用欄位

        //關鍵字欄位點擊次數
        int textBox1_click_count = 0;

        //儲存ListView1欄位用
        Dictionary<(string, string), bool> DB_DBColumn_onoff = new Dictionary<(string, string), bool>();
        Dictionary<(string, string), bool> DB_DBColumn_onoff_user = new Dictionary<(string, string), bool>();

        //儲存ListView1資料用，讀取一次資料庫後存到listview1_contents，供後續使用
        //string Line_temp = "";
        public List<string> listview1_contents = new List<string>();

        //定義一開始的進階查詢
        List<string> DB_DetailSearch_setting = new List<string>() { "不分", "不分", "不分", "不分" };

        //圖片相關參數
        String aa;                                                     //景點名稱
        List<string> photoinDir_files = new List<string>();            //存取/aa底下所有的jpg名稱
        int PhotoShow_index = 0;                                       //圖片顯示Index起始值，給上下頁使用
        
        #endregion

        #region Page2 專用function

        //取得資料庫所有資料(沒有header)，並存到listview1_contents
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

        #region Page2 專用event

        //進階篩選條件，設定可從資料庫找出哪些類型的資料(如縣市、類型等)，會影響後續查詢跟全部顯示
        private void Page2_Link_Form7(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(DB_DetailSearch_setting);
            DialogResult dlresult = f7.ShowDialog(this);

            if (dlresult == DialogResult.OK)
            {
                DB_DetailSearch_setting = f7.Result;
                MessageBox.Show("已修改完成，請重新查詢或顯示全部");
            }
        }

        //依dict判斷是否顯示，並顯示結果至listview_page2_DBshow
        private void Page2_Show_All_Databases(object sender, EventArgs e)
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

            listView_page2_DBshow.Items.Clear();
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
                    listView_page2_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
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
                    listView_page2_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
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
                    listView_page2_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
                }
                else if (listview1_line_items_hasCondition.Length == 0)
                {
                    continue;
                }
            }
        }

        //提供使用者查看，目前listview顯示的欄位，及修改顯示欄位的功能
        private void Page2_Link_Form6(object sender, EventArgs e)
        {
            List<string> new_list = new List<string>();
            int arr_count = 0;

            string[] arr = ConfigurationManager.AppSettings["DBIndex"].Split(',');
            int delete_status = Array.IndexOf(arr, "Delete_STATUS");

            if (DB_DBColumn_onoff_user.Count == 0)
            {
                Get_DBColumn_onoff();

                ColSetting_Form f6 = new ColSetting_Form(DB_DBColumn_onoff);
                DialogResult result = f6.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    listView_page2_DBshow.Columns.Clear();
                    listView_page2_DBshow.Items.Clear();
                    var list = f6.dict.Where(x => x.Value == true).Select(x => new ColumnHeader
                    {
                        Text = x.Key.Item2
                    }).ToArray();
                    listView_page2_DBshow.Columns.AddRange(list);
                    for (int i = 0; i < listView_page2_DBshow.Columns.Count; i++)
                    {
                        //MessageBox.Show(listView1.Columns[i].Text);
                        listView_page2_DBshow.Columns[i].Width = -2;
                        listView_page2_DBshow.Columns[i].Width = listView_page2_DBshow.Columns[i].Width + 100;
                    }
                }

                //秀出本來的資料
                if (listview1_contents.Count > 0)
                {
                    foreach (var listview1_contents_line in listview1_contents)
                    {
                        string[] listview1_contents_line_items = listview1_contents_line.Split(',');

                        arr_count = 0;
                        new_list.Clear();
                        foreach (var dict_item in DB_DBColumn_onoff)
                        {
                            if (dict_item.Value == true)
                            {
                                new_list.Add(listview1_contents_line_items[arr_count]);
                            }
                            arr_count += 1;
                        }
                        if (listview1_contents_line_items[delete_status] == "N")
                        {
                            listView_page2_DBshow.Items.Add(new ListViewItem(new_list.ToArray()));
                        }
                    }
                }
                DB_DBColumn_onoff_user = DB_DBColumn_onoff;
            }
            else if (DB_DBColumn_onoff_user.Count > 0)
            {
                ColSetting_Form f6 = new ColSetting_Form(DB_DBColumn_onoff_user);
                DialogResult result = f6.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    listView_page2_DBshow.Columns.Clear();
                    listView_page2_DBshow.Items.Clear();
                    var list = f6.dict.Where(x => x.Value == true).Select(x => new ColumnHeader
                    {
                        Text = x.Key.Item2
                    }).ToArray();
                    listView_page2_DBshow.Columns.AddRange(list);
                    for (int i = 0; i < listView_page2_DBshow.Columns.Count; i++)
                    {
                        //MessageBox.Show(listView1.Columns[i].Text);
                        listView_page2_DBshow.Columns[i].Width = -2;
                        listView_page2_DBshow.Columns[i].Width = listView_page2_DBshow.Columns[i].Width + 100;
                    }
                }
                DB_DBColumn_onoff_user = f6.dict;
            }

            //秀出本來的資料
            if (listview1_contents.Count > 0)
            {
                listView_page2_DBshow.Controls.Clear();
                foreach (var listview1_contents_line in listview1_contents)
                {
                    string[] listview1_contents_line_items = listview1_contents_line.Split(',');

                    arr_count = 0;
                    new_list.Clear();
                    foreach (var dict_item in DB_DBColumn_onoff_user)
                    {
                        if (dict_item.Value == true)
                        {
                            new_list.Add(listview1_contents_line_items[arr_count]);
                        }
                        arr_count += 1;
                    }
                    if (listview1_contents_line_items[delete_status] == "N")
                    {
                        listView_page2_DBshow.Items.Add(new ListViewItem(new_list.ToArray()));
                    }
                }
            }
        }

        // tBox_page2_search的點集特效，只有第一次才有作用
        private void Page2_tbox_search_click(object sender, EventArgs e)
        {
            if (textBox1_click_count == 0)
            {
                tBox_page2_search.Text = "";
                textBox1_click_count += 1;
            }
        }

        //關鍵字查詢，並考慮進階篩選的條件
        private void Page2_TextSearch_Databases(object sender, EventArgs e)
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

            if (tBox_page2_search.Text.Equals("") || tBox_page2_search.Text.Equals("請輸入關鍵字"))
            {
                MessageBox.Show("請輸入關鍵字");
            }
            else
            {
                listView_page2_DBshow.Items.Clear();
                Get_All_Databases();

                foreach (var listview1_lines in listview1_contents)
                {
                    string[] listview1_line_items_hasCondition = new string[] { };
                    string[] listview1_line_items = listview1_lines.Split(',');         //每行文字串

                    //測試用
                    //MessageBox.Show(listview1_line_items[Index_NAME]);
                    //MessageBox.Show(tBox_SearchDB.Text);


                    //判斷進階篩選條件
                    if (listview1_line_items[Index_NAME].Contains(tBox_page2_search.Text)
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
                        listView_page2_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
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
                        listView_page2_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
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
                        listView_page2_DBshow.Items.Add(new ListViewItem(listview1_line_items_temp.ToArray()));
                    }
                    else if (listview1_line_items_hasCondition.Length == 0)
                    {
                        continue;
                    }
                }
            }
        }

        //此塊功能主要目的: 當選擇了listView1上任一個名稱時，自動改變Tag內容與第一張圖片，並加上圖片上下頁功能
        private void Page2_listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView_page2_DBshow.SelectedItems.Count > 0)                                     //判斷listview有被選中項
            {
                int listView1_SelectedIndex = listView_page2_DBshow.SelectedItems[0].Index;                               //取當前選中項的index,SelectedItems[0]這必須爲0
                aa = listView_page2_DBshow.Items[listView1_SelectedIndex].SubItems[0].Text;                               //用我們剛取到的index取被選中的某一列的值從0開始
                this.PhotoShow_index = 0;

                foreach (string listview1_contents_line in listview1_contents)
                {
                    string[] listview1_contents_line_items = listview1_contents_line.Split(',');

                    if (listview1_contents_line_items[Array.IndexOf(DBIndex, "NAME")].Equals(aa))
                    {
                        //顯示tag的資訊
                        textBox2.Text = listview1_contents_line_items[Array.IndexOf(DBIndex, "TAG")];
                        btn_Photo_Upload.Visible = true;

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
                                pictureBox1.Visible = true;
                                btn_Photo_Prev.Visible = true;
                                btn_Photo_Prev.Text = "上一張";
                                btn_Photo_Prev.Enabled = false;
                                btn_Photo_Next.Visible = true;
                                btn_Photo_Next.Text = "下一張";
                                btn_Photo_Next.Enabled = true;
                                label_page2_photoinfo.Text = "現在為第1張, " + "共" + photoinDir_files.Count.ToString() + "張";
                                btn_Photo_Delete.Visible = true;
                                label_page2_photoinfo.Visible = true;
                            }
                            else if (photoinDir_files.Count == 1)
                            {
                                pictureBox1.Visible = true;
                                pictureBox1.Image = img;
                                btn_Photo_Prev.Visible = false;
                                btn_Photo_Next.Visible = false;
                                label_page2_photoinfo.Text = "現在為第1張, " + "共1張";
                                btn_Photo_Delete.Visible = true;
                                label_page2_photoinfo.Visible = true;
                            }
                        }
                        else
                        {
                            pictureBox1.Visible = true;
                            ImagesWork imgwork = new ImagesWork();
                            Image img = imgwork.getNoImage();
                            pictureBox1.Image = img;

                            //string[] img_arr = { DBImagesPath + "沒有圖片.jpg" };
                            //FileStream picture_fs = new FileStream(img_arr[0], FileMode.Open, FileAccess.Read);
                            //Image img = Image.FromStream(picture_fs);
                            //pictureBox1.Image = img;
                            btn_Photo_Prev.Visible = false;
                            btn_Photo_Next.Visible = false;
                            label_page2_photoinfo.Text = "沒有圖片";
                            btn_Photo_Delete.Visible = false;
                            label_page2_photoinfo.Visible = false;

                        }
                        break;
                    }
                }
            }
        }

        //圖片下一頁功能
        private void Page2_PhotoShow_Next(object sender, EventArgs e)
        {
            if (PhotoShow_index < photoinDir_files.Count - 1)
            {
                PhotoShow_index++;
                ImagesWork imgwork = new ImagesWork();
                pictureBox1.Image = imgwork.getImage(DBImagesPath, aa, PhotoShow_index);
                label_page2_photoinfo.Text = "現在為第" + (PhotoShow_index + 1) + "張, 共" + photoinDir_files.Count.ToString() + "張";
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
        private void Page2_PhotoShow_Prev(object sender, EventArgs e)
        {
            if (PhotoShow_index > 0)
            {
                PhotoShow_index--;
                ImagesWork imgwork = new ImagesWork();
                pictureBox1.Image = imgwork.getImage(DBImagesPath, aa, PhotoShow_index);
                label_page2_photoinfo.Text = "現在為第" + (PhotoShow_index + 1) + "張, 共" + photoinDir_files.Count.ToString() + "張";
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

        // 修改資料庫內容文字
        private void Page2_adjust_DB(object sender, EventArgs e)
        {
            if (aa is null || aa.Equals(""))
            {
                MessageBox.Show("請先點擊景點再修改!");
            }
            else
            {
                DatabaseEditor_Form f8 = new DatabaseEditor_Form(aa, listview1_contents, DBPath);
                DialogResult result = f8.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    //清除listview1
                    listView_page2_DBshow.Items.Clear();
                    MessageBox.Show("已修改，請重新下條件查詢");
                    //重讀資料庫
                }
            }
        }


        //新增圖片至資料庫的功能
        private void Page2_upload_image(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "儲存圖片至資料庫";
            dialog.InitialDirectory = ".\\";
            dialog.Multiselect = true;
            dialog.Filter = "JPEGs(*.jpg) | *.jpg; *.jpeg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImagesWork imgwork = new ImagesWork();
                imgwork.create_folder(DBImagesPath, aa);         //確定有無目錄，若沒有則建立新目錄
                imgwork.copyFile2path(DBImagesPath, aa, dialog.FileName);
                

                photoinDir_files.Clear();
                PhotoShow_index=0;
                Image img = imgwork.getImage(DBImagesPath, aa, PhotoShow_index);
                pictureBox1.Image = img;
                foreach (var x in imgwork.list_photoinDir)
                {
                    photoinDir_files.Add(x);
                }
                if (photoinDir_files.Count > 1)
                {
                    btn_Photo_Prev.Visible = true;
                    btn_Photo_Next.Visible = true;
                    btn_Photo_Delete.Visible = true;
                }
                else if (photoinDir_files.Count == 1)
                {
                    btn_Photo_Prev.Visible = false;
                    btn_Photo_Next.Visible = false;
                    btn_Photo_Delete.Visible = true;
                }
                label_page2_photoinfo.Visible = true;
                label_page2_photoinfo.Text = $"現在為第1張, 上傳後共{photoinDir_files.Count.ToString()}張";
            }
        }

        //刪除圖片的功能
        private void Page2_delete_image(object sender, EventArgs e)
        {
            //1、將圖片先換成已刪除
            ImagesWork imgwork = new ImagesWork();
            pictureBox1.Image = imgwork.getDeleteImage();
            
            //2、重新讀取路徑下有多少jpg
            photoinDir_files.Clear();
            photoinDir_files = imgwork.DeleteImage(DBImagesPath, aa, PhotoShow_index);

            if (photoinDir_files.Count > 1)
            {
                MessageBox.Show($"進入photoinDir_files.Count > 1");
                MessageBox.Show($"PhotoShow_index.ToString():{PhotoShow_index.ToString()}");
                MessageBox.Show($"photoinDir_files.Count:{photoinDir_files.Count}");

                btn_Photo_Delete.Visible = true;
                btn_Photo_Prev.Visible = true;
                btn_Photo_Next.Visible = true;
                label_page2_photoinfo.Visible = true;

                //刪除了第一章的狀況
                if (PhotoShow_index == 0)
                {
                    MessageBox.Show($"PhotoShow_index == 0");
                    PhotoShow_index = 0;
                    btn_Photo_Prev.Enabled = false;
                    btn_Photo_Next.Enabled = true;
                }
                else if (photoinDir_files.Count == PhotoShow_index)
                {
                    MessageBox.Show($"進入photoinDir_files.Count == PhotoShow_index");
                    PhotoShow_index--;
                    btn_Photo_Prev.Enabled = true;
                    btn_Photo_Next.Enabled = false;
                }
                else
                {
                    MessageBox.Show($"else");
                    btn_Photo_Prev.Enabled = true;
                    btn_Photo_Next.Enabled = true;
                }

                pictureBox1.Image = imgwork.getImage(DBImagesPath, aa, PhotoShow_index);
                label_page2_photoinfo.Text = $"現在為第{PhotoShow_index++.ToString()}張, 刪除後剩{photoinDir_files.Count.ToString()}張";
            }
            else if (photoinDir_files.Count == 1)
            {
                MessageBox.Show($"進入photoinDir_files.Count == 1");
                PhotoShow_index = 0;
                btn_Photo_Delete.Visible = true;
                btn_Photo_Prev.Visible = false;
                btn_Photo_Next.Visible = false;
                label_page2_photoinfo.Visible = true;
                label_page2_photoinfo.Text = $"現在為第1張, 刪除後剩1張";
                pictureBox1.Image = imgwork.getImage(DBImagesPath, aa, PhotoShow_index);
            }

            else if (photoinDir_files.Count == 0)
            {
                MessageBox.Show($"進入photoinDir_files.Count == 0");
                btn_Photo_Delete.Visible = false;
                btn_Photo_Prev.Visible = false;
                btn_Photo_Next.Visible = false;
                pictureBox1.Image = imgwork.getNoImage();
                label_page2_photoinfo.Visible = false;
            }
            
            MessageBox.Show("已成功刪除");


            
        }

        #endregion

        #endregion


        #region Page3功能塊***************************************************************************

        #region Page3 專用欄位
        #endregion

        #region Page3 專用function
        #endregion

        #region Page3 專用event

        //點選這一頁後，要讀取資料庫並依比數自動生成按鈕
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (tabControl1.SelectedIndex == 2)
            {
                //建立新增專案的按鈕
                flowLayoutPanel1.Controls.Clear();
                Button btn = new Button();
                btn.Size = new Size(233, 163);
                btn.Margin = new Padding(2, 30, 50, 2);
                btn.Padding = new Padding(0, 0, 0, 5);
                btn.Location = new System.Drawing.Point(123, 45);
                btn.Text = "新增旅程專案";
                btn.Font = new Font("標楷體", 9F, FontStyle.Bold);
                btn.Click += new EventHandler(Page3_CreateTripPlan);
                flowLayoutPanel1.Controls.Add(btn);

                //讀取csv，並依序建立已建立的旅程專案按鈕
                bool header_status = true;
                FileStream fs = new FileStream(DBTripPath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    switch (header_status)
                    {
                        case true:
                            header_status = false;
                            break;
                        case false:
                            Button button = new Button();
                            button.Text = "名稱: " + line[0] + "\r\n"
                                + "出發日期 :" + line[1] + "\r\n"
                                + "天數: " + line[2] + "天";
                            button.Size = new Size(233, 163);
                            button.Location = new System.Drawing.Point(0, 0);
                            button.Font = new Font("標楷體", 9F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                            button.Margin = new Padding(2, 30, 50, 2);
                            button.Padding = new Padding(0, 0, 0, 5);

                            button.Click += new EventHandler(Page3_Link_Form3);
                            string[] tagData = new string[] { line[0], line[1], line[2] };
                            button.Tag = tagData;

                            button.Image = Image.FromFile(DBImagesPath + "範例.jpg");
                            button.ImageAlign = ContentAlignment.TopCenter;
                            button.TextImageRelation = TextImageRelation.ImageAboveText;
                            button.BackColor = Color.FromArgb(220, 220, 220);
                            flowLayoutPanel1.Controls.Add(button);
                            break;
                        default:
                            break;
                    }
                }
                sr.Close();
                fs.Close();
            }
        }

        //新增旅遊專案，並同步渲染到使用者頁面
        private void Page3_CreateTripPlan(object sender, EventArgs e)
        {
            CreateNwePlan_Form f2 = new CreateNwePlan_Form(DBTripPath);
            DialogResult result = f2.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                flowLayoutPanel1.Controls.Clear();
                Button btn = new Button();
                btn.Size = new Size(233, 163);
                btn.Margin = new Padding(2, 30, 50, 2);
                btn.Padding = new Padding(0, 0, 0, 5);
                btn.Location = new System.Drawing.Point(123, 45);
                btn.Text = "新增旅程專案";
                btn.Font = new Font("標楷體", 9F, FontStyle.Bold);
                btn.Click += new EventHandler(Page3_CreateTripPlan);
                flowLayoutPanel1.Controls.Add(btn);

                bool header_status = true;
                FileStream fs = new FileStream(DBTripPath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);


                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    switch (header_status)
                    {
                        case true:
                            header_status = false;
                            break;
                        case false:
                            Button button = new Button();
                            button.Text = "名稱: " + line[0] + "\r\n"
                                + "出發日期 :" + line[1] + "\r\n"
                                + "天數: " + line[2] + "天";
                            button.Size = new Size(233, 163);
                            button.Location = new System.Drawing.Point(0, 0);
                            button.Font = new Font("標楷體", 9F, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                            button.Margin = new Padding(2, 30, 50, 2);
                            button.Padding = new Padding(0, 0, 0, 5);

                            button.Click += new EventHandler(Page3_Link_Form3);
                            string[] tagData = new string[] { line[0], line[1], line[2] };
                            button.Tag = tagData;

                            button.Image = Image.FromFile(DBImagesPath + "範例.jpg");
                            button.ImageAlign = ContentAlignment.TopCenter;
                            button.TextImageRelation = TextImageRelation.ImageAboveText;
                            button.BackColor = Color.FromArgb(220, 220, 220);
                            flowLayoutPanel1.Controls.Add(button);
                            break;
                        default:
                            break;
                    }
                }
                sr.Close();
                fs.Close();
            }
        }

        //page3_點選既有旅程，並跳出Form3的介面
        private void Page3_Link_Form3(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string[] tagData = (string[])button.Tag;

            string path = DBTripCSVPath + tagData[0] + "_" + tagData[1] + "_" + tagData[2];
            //測試用
            //MessageBox.Show(path);
            if (!Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);//不存在就建立目錄
            }

            PlanEditor_Form f3 = new PlanEditor_Form(tagData);
            f3.ShowDialog(this);
        }








        #endregion

        #endregion

        private void gbox_page1_cef_Enter(object sender, EventArgs e)
        {

        }
    }
}
