using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊行程產生器
{
    class ImagesWork
    {
        public List<string> list_photoinDir = new List<string>();
        public Image getImage(string image_path, string aa, int photo_listindex)
        {
            string[] FileCollection = Directory.GetFiles(image_path + aa, "*.jpg");

            FileInfo theFileInfo;

            for (int i = 0; i < FileCollection.Length; i++)
            {
                theFileInfo = new FileInfo(FileCollection[i]);
                list_photoinDir.Add(theFileInfo.Name);
            }
            //string[] img_arr = { image_path + aa + "\\" + list_photoinDir[photo_listindex] };
            string img_source = image_path + aa + "\\" + list_photoinDir[photo_listindex];
            FileStream picture_fs = new FileStream(img_source, FileMode.Open, FileAccess.Read);
            Image img = Image.FromStream(picture_fs);
            picture_fs.Close();
            return img;
        }

        public Image getNoImage()
        {
            string image_path = ConfigurationManager.AppSettings["DBImagesPath"];
            string[] img_arr = { image_path + "\\" + "沒有圖片.jpg" };
            FileStream picture_fs = new FileStream(img_arr[0], FileMode.Open, FileAccess.Read);
            Image img = Image.FromStream(picture_fs);
            return img;
        }
        public Image getDeleteImage()
        {
            //回傳刪除模板圖片
            string image_path = ConfigurationManager.AppSettings["DBImagesPath"];
            string img_delete = image_path + "\\" + "圖片已被刪除.jpg";
            FileStream picture_fs = new FileStream(img_delete, FileMode.Open, FileAccess.Read);
            Image img = Image.FromStream(picture_fs);
            return img;
        }

        public List<string> DeleteImage(string image_path, string aa, int photo_listindex)
        {
            string[] FileCollection;

            //先取得list_photoinDir
            FileCollection = Directory.GetFiles(image_path + aa, "*.jpg");
            FileInfo theFileInfo;

            for (int i = 0; i < FileCollection.Length; i++)
            {
                theFileInfo = new FileInfo(FileCollection[i]);
                list_photoinDir.Add(theFileInfo.Name);
            }

            //1、取得要刪除的jpg名稱
            string img_deletedd = image_path + aa + "\\" + list_photoinDir[photo_listindex];

            //2、如果要刪除的photo_listindex是1以上，代表多個jpg，如果是0則要考慮是不是唯一圖檔，是的話刪掉整個路徑
            if (File.Exists(img_deletedd) && File.Exists(img_deletedd) && photo_listindex >= 1)
            {
                MessageBox.Show($"有多個圖檔，刪除{list_photoinDir[photo_listindex]}.jpg");
                File.Delete(img_deletedd);
            }
            else if (File.Exists(img_deletedd) && File.Exists(img_deletedd) && photo_listindex == 0)
            {
                FileCollection = Directory.GetFiles(image_path + aa, "*.jpg");
                if (FileCollection.Length > 1)
                {
                    MessageBox.Show($"有多個圖檔，刪除{list_photoinDir[photo_listindex]}.jpg");
                    File.Delete(img_deletedd);
                }
                else
                {
                    MessageBox.Show($"只有一個圖檔，刪除.//{image_path + aa}");
                    DirectoryInfo di = new DirectoryInfo(image_path + aa);
                    di.Delete(true);
                    //Directory.Delete(image_path + aa);
                }
            }

            //3、將list_photoinDir重新清空，再次查詢並重新放入
            list_photoinDir.Clear();
            if (Directory.Exists(image_path + aa))
            {
                FileCollection = Directory.GetFiles(image_path + aa, "*.jpg");

                for (int i = 0; i < FileCollection.Length; i++)
                {
                    theFileInfo = new FileInfo(FileCollection[i]);
                    list_photoinDir.Add(theFileInfo.Name);
                }
            }
            
            return list_photoinDir;
        }

        public void create_folder(string image_save_path, string aa)
        {
            string new_path = image_save_path + aa + "\\";
            System.IO.Directory.CreateDirectory(new_path);
        }

        public void copyFile2path(string image_save_path, string aa, string image_get_path)
        {

            string filename = System.IO.Path.GetFileName(image_get_path);
            string new_filename = image_save_path + aa + "\\" + filename;
            Console.WriteLine(filename);
            Console.WriteLine(new_filename);
            if (!File.Exists(new_filename))
            {
                System.IO.File.Copy(image_get_path, new_filename, true);
                MessageBox.Show("已上傳成功!!");
            }
            else
            {
                MessageBox.Show("此相片已經上傳過了!");
            }
        }
        public void moveFile2path(string image_save_path, string aa, string image_get_path)
        {
            string new_path = image_save_path + aa + "\\" + "delete";
            System.IO.Directory.CreateDirectory(new_path);

            string filename = image_save_path + aa + "\\" + image_get_path;
            string new_filename = new_path + "\\" + image_get_path;

            Console.WriteLine($"image_get_path:{image_get_path}");
            Console.WriteLine($"filename:{filename}");
            Console.WriteLine($"new_filename:{new_filename}");
            System.IO.File.Copy(filename, new_filename,true);
        }
    }
}
