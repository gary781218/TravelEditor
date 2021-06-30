using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊行程產生器
{
    public static class Extension_Gbox

    {
        public static GroupBox create(this GroupBox gbox,
            int Size_x, int Size_y,
            int Location_x, int Location_y,
            int R, int G, int B,
            int Fontsize,
            string text = "")
        {
            gbox.Text = text == null ? "Textbox" : text;
            gbox.Size = new System.Drawing.Size(Size_x, 100);
            gbox.Location = new System.Drawing.Point(Location_x, Location_y);
            gbox.BackColor = Color.FromArgb(R, G, B);
            gbox.Margin = new Padding(0);
            gbox.Font = new System.Drawing.Font("標楷體", Fontsize);
            return gbox;
        }

        public static GroupBox create_AutoSize(this GroupBox gbox,
            int Size_x, int Size_y,
            int Location_x, int Location_y,
            int R, int G, int B,
            int Fontsize,
            string text = "")
        {
            gbox.Text = text == null ? "Textbox" : text;
            gbox.Size = new System.Drawing.Size(Size_x, 100);
            gbox.Location = new System.Drawing.Point(Location_x, Location_y);
            gbox.BackColor = Color.FromArgb(R, G, B);
            gbox.AutoSize = true;
            gbox.Margin = new Padding(0);
            gbox.Font = new System.Drawing.Font("標楷體", Fontsize);
            return gbox;
        }
    }
}
