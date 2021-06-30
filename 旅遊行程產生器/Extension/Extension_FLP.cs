using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊行程產生器
{
    public static class Extension_FLP
    {
        public static FlowLayoutPanel create_row(this FlowLayoutPanel flp,
            int Size_x, int Size_y,
            int Fontsize,
            string text = "")
        {
            flp.Text = text == null ? "FlowLayoutPanel" : text;
            flp.Size = new System.Drawing.Size(Size_x, Size_y);
            flp.Margin = new Padding(15,40,0,0);
            flp.BackColor = Color.FromArgb(220, 220, 220);
            flp.Font = new System.Drawing.Font("標楷體", Fontsize);
            return flp;
        }
    }
}
