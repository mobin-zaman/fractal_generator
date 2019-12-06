using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using MySql.Data;
using MySql.Data.MySqlClient;
using fractal_generator.Database;

namespace fractal_generator.Model
{
    class Fractal
    {
        private int id;
        private String name;
        private String description;
        private String thumbUrl;
        private BitmapImage imageData;

        public Fractal(MySqlDataReader reader)
        {
            id = Int32.Parse(reader.GetString(0));
            name = reader.GetString(1);
            description = reader.GetString(2);
            thumbUrl = reader.GetString(3);
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public String Description
        {
            get { return this.Description; }
            set { this.description = value; }
        }

        public BitmapImage ImageData
        {
            get { return this.LoadImage(); }
        }



        public Fractal()
        {

        }



        public String getThumbUrl()
        {
            String parentPath = GetParent(Directory.GetCurrentDirectory(), "fractal_generator");
            string[] paths = {parentPath, "Model", "Images", thumbUrl};
            String imagePath = Path.Combine(paths);
            return imagePath;

        }

        public string GetParent(string path, string parentName) //needed for thumburl
            {
            var dir = new DirectoryInfo(path);

            if (dir.Parent == null)
            {
                return null;
            }

            if (dir.Parent.Name == parentName)
            {
                return dir.Parent.FullName;
            }

            return this.GetParent(dir.Parent.FullName, parentName);
        }

        private BitmapImage LoadImage()
        {
            return new BitmapImage(new Uri(getThumbUrl()));
        }

        public  static List<Fractal> GetFractalList()
        {

            string sql = "select * from fractal"; //TODO: see the difference between string and String
            var reader = DB.ExecuteSql(sql);
            List<Fractal> fractalList = new List<Fractal>();
            while (reader.Read())
            {
                Fractal f = new Fractal(reader);
                fractalList.Add(f);
            }

            return fractalList;
            
        }

        //public static Uri 
    }
}
