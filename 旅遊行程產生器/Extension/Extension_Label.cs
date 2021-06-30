using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊行程產生器
{
    public static class Extension_Label
    {
        public static System.Windows.Forms.Label create(this System.Windows.Forms.Label label,
            int Size_x, int Size_y,
            int Location_x, int Location_y,
            string text = "")
        {
            label.Text = text == "" ? "未命名label" : text;
            label.Size = new System.Drawing.Size(Size_x, Size_y);
            label.Location = new System.Drawing.Point(Location_x, Location_y);
            //label.BackColor = Color.FromArgb(220, 220, 220);
            label.Margin = new Padding(0);
            label.Font = new Font("標楷體", 12);
            return label;
        }
    }
}
