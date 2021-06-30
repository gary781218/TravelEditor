namespace 旅遊行程產生器
{
    partial class CitySelector_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.userControl11 = new AutoComplate.UserControl1();
            this.userControl12 = new AutoComplate.UserControl1();
            this.userControl13 = new AutoComplate.UserControl1();
            this.userControl14 = new AutoComplate.UserControl1();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(33, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "區域";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(33, 281);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "是否去過";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(33, 205);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "類型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(33, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "縣市";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(344, 379);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 35);
            this.button2.TabIndex = 26;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 379);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 35);
            this.button1.TabIndex = 25;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // userControl11
            // 
            this.userControl11.displaymenber = "key";
            this.userControl11.disvaluemenber = "value";
            this.userControl11.Location = new System.Drawing.Point(106, 28);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(297, 245);
            this.userControl11.TabIndex = 31;
            // 
            // userControl12
            // 
            this.userControl12.displaymenber = "key";
            this.userControl12.disvaluemenber = "value";
            this.userControl12.Location = new System.Drawing.Point(106, 103);
            this.userControl12.Name = "userControl12";
            this.userControl12.Size = new System.Drawing.Size(297, 245);
            this.userControl12.TabIndex = 32;
            // 
            // userControl13
            // 
            this.userControl13.displaymenber = "key";
            this.userControl13.disvaluemenber = "value";
            this.userControl13.Location = new System.Drawing.Point(106, 178);
            this.userControl13.Name = "userControl13";
            this.userControl13.Size = new System.Drawing.Size(297, 245);
            this.userControl13.TabIndex = 33;
            // 
            // userControl14
            // 
            this.userControl14.displaymenber = "key";
            this.userControl14.disvaluemenber = "value";
            this.userControl14.Location = new System.Drawing.Point(106, 251);
            this.userControl14.Name = "userControl14";
            this.userControl14.Size = new System.Drawing.Size(297, 245);
            this.userControl14.TabIndex = 34;
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userControl14);
            this.Controls.Add(this.userControl13);
            this.Controls.Add(this.userControl12);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form10";
            this.Text = "都市篩選";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private AutoComplate.UserControl1 userControl11;
        private AutoComplate.UserControl1 userControl12;
        private AutoComplate.UserControl1 userControl13;
        private AutoComplate.UserControl1 userControl14;
    }
}