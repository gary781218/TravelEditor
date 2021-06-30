namespace 旅遊行程產生器
{
    partial class Form_Index
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Index));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbox_page1_cef = new System.Windows.Forms.GroupBox();
            this.flp_page1_result = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_page1_search = new System.Windows.Forms.Button();
            this.tbox_page1_search = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.btn_Photo_Delete = new System.Windows.Forms.Button();
            this.btn_Photo_Upload = new System.Windows.Forms.Button();
            this.label_page2_photoinfo = new System.Windows.Forms.Label();
            this.btn_Photo_Next = new System.Windows.Forms.Button();
            this.btn_Photo_Prev = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tBox_page2_search = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.listView_page2_DBshow = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2007, 1350);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.MintCream;
            this.tabPage1.Controls.Add(this.gbox_page1_cef);
            this.tabPage1.Controls.Add(this.flp_page1_result);
            this.tabPage1.Controls.Add(this.btn_page1_search);
            this.tabPage1.Controls.Add(this.tbox_page1_search);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1999, 1312);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "新增景點";
            // 
            // gbox_page1_cef
            // 
            this.gbox_page1_cef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gbox_page1_cef.Location = new System.Drawing.Point(690, 31);
            this.gbox_page1_cef.Margin = new System.Windows.Forms.Padding(4);
            this.gbox_page1_cef.Name = "gbox_page1_cef";
            this.gbox_page1_cef.Padding = new System.Windows.Forms.Padding(4);
            this.gbox_page1_cef.Size = new System.Drawing.Size(1284, 1258);
            this.gbox_page1_cef.TabIndex = 4;
            this.gbox_page1_cef.TabStop = false;
            this.gbox_page1_cef.Enter += new System.EventHandler(this.gbox_page1_cef_Enter);
            // 
            // flp_page1_result
            // 
            this.flp_page1_result.AutoScroll = true;
            this.flp_page1_result.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flp_page1_result.Location = new System.Drawing.Point(18, 95);
            this.flp_page1_result.Margin = new System.Windows.Forms.Padding(4);
            this.flp_page1_result.Name = "flp_page1_result";
            this.flp_page1_result.Size = new System.Drawing.Size(649, 1194);
            this.flp_page1_result.TabIndex = 3;
            // 
            // btn_page1_search
            // 
            this.btn_page1_search.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_page1_search.Location = new System.Drawing.Point(499, 31);
            this.btn_page1_search.Margin = new System.Windows.Forms.Padding(4);
            this.btn_page1_search.Name = "btn_page1_search";
            this.btn_page1_search.Size = new System.Drawing.Size(168, 36);
            this.btn_page1_search.TabIndex = 1;
            this.btn_page1_search.Text = "查詢";
            this.btn_page1_search.UseVisualStyleBackColor = true;
            this.btn_page1_search.Click += new System.EventHandler(this.Page1_Search_Click);
            // 
            // tbox_page1_search
            // 
            this.tbox_page1_search.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbox_page1_search.Location = new System.Drawing.Point(18, 31);
            this.tbox_page1_search.Margin = new System.Windows.Forms.Padding(4);
            this.tbox_page1_search.Name = "tbox_page1_search";
            this.tbox_page1_search.Size = new System.Drawing.Size(458, 36);
            this.tbox_page1_search.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Aqua;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1999, 1312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "景點庫";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button22);
            this.groupBox3.Controls.Add(this.btn_Photo_Delete);
            this.groupBox3.Controls.Add(this.btn_Photo_Upload);
            this.groupBox3.Controls.Add(this.label_page2_photoinfo);
            this.groupBox3.Controls.Add(this.btn_Photo_Next);
            this.groupBox3.Controls.Add(this.btn_Photo_Prev);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.tBox_page2_search);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.listView_page2_DBshow);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(12, 8);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1976, 1290);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "資料庫修改";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(12, 38);
            this.button11.Margin = new System.Windows.Forms.Padding(4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(225, 45);
            this.button11.TabIndex = 24;
            this.button11.Text = "全部顯示";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Page2_Show_All_Databases);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1743, 36);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(225, 45);
            this.button3.TabIndex = 23;
            this.button3.Text = "進階篩選條件";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Page2_Link_Form7);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(244, 39);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(225, 45);
            this.button22.TabIndex = 13;
            this.button22.Text = "顯示欄位";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.Page2_Link_Form6);
            // 
            // btn_Photo_Delete
            // 
            this.btn_Photo_Delete.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Photo_Delete.Location = new System.Drawing.Point(752, 623);
            this.btn_Photo_Delete.Name = "btn_Photo_Delete";
            this.btn_Photo_Delete.Size = new System.Drawing.Size(150, 45);
            this.btn_Photo_Delete.TabIndex = 22;
            this.btn_Photo_Delete.Text = "刪除圖片";
            this.btn_Photo_Delete.UseVisualStyleBackColor = true;
            this.btn_Photo_Delete.Visible = false;
            this.btn_Photo_Delete.Click += new System.EventHandler(this.Page2_delete_image);
            // 
            // btn_Photo_Upload
            // 
            this.btn_Photo_Upload.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Photo_Upload.Location = new System.Drawing.Point(578, 623);
            this.btn_Photo_Upload.Name = "btn_Photo_Upload";
            this.btn_Photo_Upload.Size = new System.Drawing.Size(150, 45);
            this.btn_Photo_Upload.TabIndex = 17;
            this.btn_Photo_Upload.Text = "新增圖片";
            this.btn_Photo_Upload.UseVisualStyleBackColor = true;
            this.btn_Photo_Upload.Visible = false;
            this.btn_Photo_Upload.Click += new System.EventHandler(this.Page2_upload_image);
            // 
            // label_page2_photoinfo
            // 
            this.label_page2_photoinfo.AutoSize = true;
            this.label_page2_photoinfo.Location = new System.Drawing.Point(789, 1221);
            this.label_page2_photoinfo.Name = "label_page2_photoinfo";
            this.label_page2_photoinfo.Size = new System.Drawing.Size(303, 32);
            this.label_page2_photoinfo.TabIndex = 21;
            this.label_page2_photoinfo.Text = "共n張，現在為第1張";
            this.label_page2_photoinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_page2_photoinfo.Visible = false;
            // 
            // btn_Photo_Next
            // 
            this.btn_Photo_Next.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Photo_Next.Location = new System.Drawing.Point(1290, 931);
            this.btn_Photo_Next.Name = "btn_Photo_Next";
            this.btn_Photo_Next.Size = new System.Drawing.Size(188, 45);
            this.btn_Photo_Next.TabIndex = 20;
            this.btn_Photo_Next.Text = "下一張";
            this.btn_Photo_Next.UseVisualStyleBackColor = true;
            this.btn_Photo_Next.Visible = false;
            this.btn_Photo_Next.Click += new System.EventHandler(this.Page2_PhotoShow_Next);
            // 
            // btn_Photo_Prev
            // 
            this.btn_Photo_Prev.Enabled = false;
            this.btn_Photo_Prev.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Photo_Prev.Location = new System.Drawing.Point(342, 931);
            this.btn_Photo_Prev.Name = "btn_Photo_Prev";
            this.btn_Photo_Prev.Size = new System.Drawing.Size(188, 45);
            this.btn_Photo_Prev.TabIndex = 19;
            this.btn_Photo_Prev.Text = "上一張";
            this.btn_Photo_Prev.UseVisualStyleBackColor = true;
            this.btn_Photo_Prev.Visible = false;
            this.btn_Photo_Prev.Click += new System.EventHandler(this.Page2_PhotoShow_Prev);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(578, 674);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(679, 526);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // tBox_page2_search
            // 
            this.tBox_page2_search.Location = new System.Drawing.Point(1185, 34);
            this.tBox_page2_search.Name = "tBox_page2_search";
            this.tBox_page2_search.Size = new System.Drawing.Size(418, 45);
            this.tBox_page2_search.TabIndex = 0;
            this.tBox_page2_search.Text = "請輸入關鍵字";
            this.tBox_page2_search.Click += new System.EventHandler(this.Page2_tbox_search_click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1611, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "查詢";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Page2_TextSearch_Databases);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(16, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "重點行程";
            // 
            // listView_page2_DBshow
            // 
            this.listView_page2_DBshow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10});
            this.listView_page2_DBshow.GridLines = true;
            this.listView_page2_DBshow.HideSelection = false;
            this.listView_page2_DBshow.Location = new System.Drawing.Point(9, 90);
            this.listView_page2_DBshow.Name = "listView_page2_DBshow";
            this.listView_page2_DBshow.Size = new System.Drawing.Size(1962, 346);
            this.listView_page2_DBshow.TabIndex = 9;
            this.listView_page2_DBshow.UseCompatibleStateImageBehavior = false;
            this.listView_page2_DBshow.View = System.Windows.Forms.View.Details;
            this.listView_page2_DBshow.SelectedIndexChanged += new System.EventHandler(this.Page2_listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "景點名稱";
            this.columnHeader1.Width = 191;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "地址";
            this.columnHeader2.Width = 192;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "電話";
            this.columnHeader3.Width = 212;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "類型";
            this.columnHeader4.Width = 231;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "星數";
            this.columnHeader5.Width = 141;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "建議停留";
            this.columnHeader6.Width = 220;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "URL";
            this.columnHeader7.Width = 228;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "網址";
            this.columnHeader9.Width = 305;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "新增日期";
            this.columnHeader10.Width = 521;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 489);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1940, 79);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "\r\n";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(476, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 45);
            this.button2.TabIndex = 10;
            this.button2.Text = "修改表單";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Page2_adjust_DB);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flowLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1999, 1312);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "旅程安排";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1995, 1025);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(123, 45);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 45, 75, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(350, 244);
            this.button4.TabIndex = 0;
            this.button4.Text = "新增旅程專案";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Page3_CreateTripPlan);
            // 
            // Form_Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "專案一_旅遊行程編輯器";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView_page2_DBshow;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tBox_page2_search;
        private System.Windows.Forms.TabPage tabPage3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label_page2_photoinfo;
        private System.Windows.Forms.Button btn_Photo_Next;
        private System.Windows.Forms.Button btn_Photo_Prev;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Photo_Upload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_Photo_Delete;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_page1_search;
        private System.Windows.Forms.TextBox tbox_page1_search;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.FlowLayoutPanel flp_page1_result;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gbox_page1_cef;
    }
}

