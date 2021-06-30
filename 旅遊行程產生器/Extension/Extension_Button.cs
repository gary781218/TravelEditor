using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊行程產生器
{
    public static class Extension_Button
    {
        public static Button create(this Button button,
            int Size_x, int Size_y, 
            int Location_x, int Location_y,
            string text="")
        {
            button.Text = text == "" ? "未命名button" : text;
            button.Size = new System.Drawing.Size(Size_x, Size_y);
            button.Location = new System.Drawing.Point(Location_x, Location_y);
            button.BackColor = Color.FromArgb(220, 220, 220);
            button.Margin = new Padding(0);
            return button;
        }

        public static Button create_page3(this Button button,
            int Size_x, int Size_y,
            int Location_x, int Location_y,
            string text_name, string text_date, string text_day)
        {
            button.Text = "名稱:" + text_name + "\r\n" 
                + "出發日期:" + text_date + "\r\n"
                + "天數:" + text_day + "天";
            button.Size = new System.Drawing.Size(Size_x, Size_y); // 233,163
            button.Location = new System.Drawing.Point(Location_x, Location_y);
            button.Font = new Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            button.ImageAlign = ContentAlignment.TopCenter;
            button.TextImageRelation = TextImageRelation.ImageAboveText;
            button.BackColor = Color.FromArgb(220, 220, 220);
            button.Margin = new Padding(0);
            return button;
        }
    }
}
