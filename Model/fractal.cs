using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace fractal_generator.Model
{
    class Fractal
    {
        private int id;
        private String name;
        private String description;
        private String thumbUrl;

        public Fractal(MySqlDataReader reader)
        {
            id = Int32.Parse(reader.GetString(0));
            name = reader.GetString(1);
            description = reader.GetString(2);
            thumbUrl = reader.GetString(3);
        }

        public Fractal()
        {

        }


        public int getId()
        {
            return id;
        }

        public String getName()
        {
            return name;
        }

        public String getDescription()
        {
            return description;
        }

        public String getThumbUrl()
        {
            String parentPath = GetParent(Directory.GetCurrentDirectory(), "fractal_generator");
            string[] paths = {parentPath, "Model", "Image", thumbUrl};
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

        public  static List<Fractal> GetFractalList(MySqlDataReader reader)
        {
            List<Fractal> fractalList = new List<Fractal>();
            while (reader.Read())
            {
                Fractal f = new Fractal(reader);
                fractalList.Add(f);
            }

            return fractalList;
            
        }
    }
}
