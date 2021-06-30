namespace 旅遊行程產生器
{
    partial class PlanEditor_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanEditor_Form));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_page3_photoinfo = new System.Windows.Forms.Label();
            this.btn_Photo_Next = new System.Windows.Forms.Button();
            this.btn_Photo_Prev = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.tBox_page3_search = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listView_page3_DBshow = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button21 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.Travel_Save = new System.Windows.Forms.Button();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 1064);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(452, 500);
            this.flowLayoutPanel1.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(9, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 24);
            this.label3.TabIndex = 41;
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(1342, 923);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "從資料庫中找景點";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox3.Controls.Add(this.label_page3_photoinfo);
            this.groupBox3.Controls.Add(this.btn_Photo_Next);
            this.groupBox3.Controls.Add(this.btn_Photo_Prev);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Controls.Add(this.tBox_page3_search);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.listView_page3_DBshow);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(5, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1319, 902);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "資料庫修改";
            // 
            // label_page3_photoinfo
            // 
            this.label_page3_photoinfo.AutoSize = true;
            this.label_page3_photoinfo.Location = new System.Drawing.Point(560, 852);
            this.label_page3_photoinfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_page3_photoinfo.Name = "label_page3_photoinfo";
            this.label_page3_photoinfo.Size = new System.Drawing.Size(208, 21);
            this.label_page3_photoinfo.TabIndex = 32;
            this.label_page3_photoinfo.Text = "共n張，現在為第1張";
            this.label_page3_photoinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Photo_Next
            // 
            this.btn_Photo_Next.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Photo_Next.Location = new System.Drawing.Point(898, 659);
            this.btn_Photo_Next.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Photo_Next.Name = "btn_Photo_Next";
            this.btn_Photo_Next.Size = new System.Drawing.Size(125, 30);
            this.btn_Photo_Next.TabIndex = 31;
            this.btn_Photo_Next.Text = "下一張";
            this.btn_Photo_Next.UseVisualStyleBackColor = true;
            this.btn_Photo_Next.Click += new System.EventHandler(this.Page3_PhotoShow_Next);
            // 
            // btn_Photo_Prev
            // 
            this.btn_Photo_Prev.Enabled = false;
            this.btn_Photo_Prev.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Photo_Prev.Location = new System.Drawing.Point(266, 659);
            this.btn_Photo_Prev.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Photo_Prev.Name = "btn_Photo_Prev";
            this.btn_Photo_Prev.Size = new System.Drawing.Size(125, 30);
            this.btn_Photo_Prev.TabIndex = 30;
            this.btn_Photo_Prev.Text = "上一張";
            this.btn_Photo_Prev.UseVisualStyleBackColor = true;
            this.btn_Photo_Prev.Click += new System.EventHandler(this.Page3_PhotoShow_Prev);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(423, 488);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(453, 351);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button8.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button8.Location = new System.Drawing.Point(1153, 71);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(150, 30);
            this.button8.TabIndex = 27;
            this.button8.Tag = "DB";
            this.button8.Text = "加入旅程";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Page3_Link_Form9);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(377, 25);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 30);
            this.button5.TabIndex = 26;
            this.button5.Text = "進階篩選條件";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Page3_Link_Form7);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(293, 24);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 30);
            this.button2.TabIndex = 25;
            this.button2.Text = "查詢";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Page3_TextSearch_Databases);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(9, 71);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(150, 30);
            this.button11.TabIndex = 24;
            this.button11.Text = "全部顯示";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Show_All_Databases);
            // 
            // tBox_page3_search
            // 
            this.tBox_page3_search.Location = new System.Drawing.Point(9, 25);
            this.tBox_page3_search.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_page3_search.Name = "tBox_page3_search";
            this.tBox_page3_search.Size = new System.Drawing.Size(280, 33);
            this.tBox_page3_search.TabIndex = 0;
            this.tBox_page3_search.Text = "請輸入關鍵字";
            this.tBox_page3_search.Click += new System.EventHandler(this.textBox1_click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(12, 349);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "重點行程";
            // 
            // listView_page3_DBshow
            // 
            this.listView_page3_DBshow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader9});
            this.listView_page3_DBshow.GridLines = true;
            this.listView_page3_DBshow.HideSelection = false;
            this.listView_page3_DBshow.Location = new System.Drawing.Point(9, 105);
            this.listView_page3_DBshow.Margin = new System.Windows.Forms.Padding(2);
            this.listView_page3_DBshow.Name = "listView_page3_DBshow";
            this.listView_page3_DBshow.Size = new System.Drawing.Size(1305, 232);
            this.listView_page3_DBshow.TabIndex = 9;
            this.listView_page3_DBshow.UseCompatibleStateImageBehavior = false;
            this.listView_page3_DBshow.View = System.Windows.Forms.View.Details;
            this.listView_page3_DBshow.SelectedIndexChanged += new System.EventHandler(this.Page3_listView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "景點名稱";
            this.columnHeader1.Width = 253;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "地址";
            this.columnHeader2.Width = 302;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "電話";
            this.columnHeader3.Width = 278;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "類型";
            this.columnHeader4.Width = 242;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "星數";
            this.columnHeader5.Width = 201;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "建議停留";
            this.columnHeader6.Width = 193;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "網址";
            this.columnHeader9.Width = 479;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 377);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1305, 54);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "\r\n";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Controls.Add(this.button21);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1342, 923);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "從googleMap API 找景點";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 909);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "google map";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1004, 48);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(327, 866);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button21.Location = new System.Drawing.Point(1257, 13);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 28);
            this.button21.TabIndex = 5;
            this.button21.Text = "查詢";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.Page1_Search_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox3.Location = new System.Drawing.Point(1006, 14);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(246, 27);
            this.textBox3.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 34);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1350, 949);
            this.tabControl1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(14, -96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 42;
            this.label1.Text = "旅程安排";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(7, 1008);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "旅程安排";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(9, 1029);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1338, 31);
            this.flowLayoutPanel3.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 21);
            this.label4.TabIndex = 45;
            this.label4.Text = "旅程專案name";
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(468, 1064);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(879, 499);
            this.gMapControl1.TabIndex = 46;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl2_Load_1);
            this.gMapControl1.DoubleClick += new System.EventHandler(this.gMapControl2_click);
            // 
            // Travel_Save
            // 
            this.Travel_Save.BackColor = System.Drawing.Color.LightCoral;
            this.Travel_Save.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Travel_Save.Location = new System.Drawing.Point(1227, 1005);
            this.Travel_Save.Name = "Travel_Save";
            this.Travel_Save.Size = new System.Drawing.Size(120, 28);
            this.Travel_Save.TabIndex = 8;
            this.Travel_Save.Text = "儲存編輯內容";
            this.Travel_Save.UseVisualStyleBackColor = false;
            this.Travel_Save.Click += new System.EventHandler(this.Travel_Save_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1450, 647);
            this.Controls.Add(this.Travel_Save);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form3";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Form3";
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox tBox_page3_search;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView_page3_DBshow;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button Travel_Save;
        private System.Windows.Forms.Label label_page3_photoinfo;
        private System.Windows.Forms.Button btn_Photo_Next;
        private System.Windows.Forms.Button btn_Photo_Prev;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}