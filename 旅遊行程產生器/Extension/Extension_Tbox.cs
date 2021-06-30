using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊行程產生器
{
    public static class Extension_Tbox
    {
        public static TextBox create(this TextBox textbox,
            int Size_x, int FontSize,
            int Location_x, int Location_y,
            string text = "")
        {
            textbox.Text = text == "" ? "Textbox" : text;
            textbox.Size = new System.Drawing.Size(Size_x, 100);
            textbox.Location = new System.Drawing.Point(Location_x, Location_y);
            //label.BackColor = Color.FromArgb(220, 220, 220);
            textbox.Margin = new Padding(0);
            textbox.Font = new System.Drawing.Font("標楷體", 12);
            return textbox;
        }
    }
}
