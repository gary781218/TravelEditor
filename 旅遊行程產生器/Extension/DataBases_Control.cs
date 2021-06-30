using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊行程產生器.Model;

namespace 旅遊行程產生器
{
    class DataBases_Control
    {
        string path;
        string keyword;

        public DataBases_Control(string path) 
        {
            this.path = path;
        }
        public DataBases_Control(string path, string keyword)
        {
            this.path = path;
            this.keyword = keyword;
        }

        //取得DB的line數
        public int DBCount
        {
            get
            {
                int count = 0;
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);

                while (!sw.EndOfStream)
                {
                    count = int.Parse(sw.ReadLine());
                }
                sw.Close();
                fs.Close();
                Console.WriteLine(count);
                return count;
            }
        }

        public List<string> DBC_Search_for_Line
        {
            get
            {
                List<string> data = new List<string>();
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);

                while (!sw.EndOfStream)
                {
                    string line = sw.ReadLine();
                    string[] arr = line.Split(',');
                    if (arr[1].Equals(keyword))
                    {
                        foreach (var x in arr)
                        {
                            data.Add(x);
                        }
                    }
                }
                sw.Close();
                fs.Close();
                return data;
            }
        }

        public List<string> DBC_Search_from_placeid
        {
            get
            {
                List<string> data = new List<string>();
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);

                while (!sw.EndOfStream)
                {
                    string line = sw.ReadLine();
                    string[] arr = line.Split(',');
                    if (arr[1].Equals(keyword))
                    {
                        foreach (var x in arr)
                        {
                            data.Add(x);
                        }
                    }
                }
                sw.Close();
                fs.Close();
                return data;
            }
        }

        public void DBMaker() 
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            fs.Close();
        }
        public List<string> DBReader(bool _hasHeader)
        {
            bool hasHeader = _hasHeader;
            string line;

            List<string> list = new List<string>();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            while (!sw.EndOfStream)                                               //重頭讀到尾
            {
                line = sw.ReadLine();
                switch (hasHeader)
                {
                    case true:
                        hasHeader = false;
                        break;

                    case false:
                        list.Add(line);
                        Console.WriteLine(line);
                        break;
                    default:
                        continue;
                }

            }
            sw.Close();
            fs.Close();
            return list;
        }

        public void DBReader_search()
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            while (!sw.EndOfStream)
            {
                Console.WriteLine(sw.ReadLine());
            }
            sw.Close();
            fs.Close();
        }

        public void DBWriter(string[] string_arr)
        {
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            string str ="";
            foreach (var x in string_arr)
            {
                str += x == string_arr.Last() ? x : x + ",";
            }
            sw.WriteLine(str);
            sw.Close();
            fs.Close();
        }
        public void DBWriter_cover(string[] string_arr)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            string str = "";
            foreach (var x in string_arr)
            {
                str += x == string_arr.Last() ? x : x + ",";
            }
            sw.WriteLine(str);
            sw.Close();
            fs.Close();
        }
    }
}
