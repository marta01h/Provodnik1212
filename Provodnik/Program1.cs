using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practical6
{
    public class ReadSave
    {
        public static List<Figure> Read(string path)
        {
            int i = 0;
            List<Figure> figures = new List<Figure>();
            if (path[path.Length - 1] == 't')
            {
                string[] text = File.ReadAllLines(path);
                do
                {
                    Figure newFigure = new Figure(text[i], int.Parse(text[i + 1]), int.Parse(text[i + 2]));
                    figures.Add(newFigure);
                    i += 3;
                } while (text.Length > i);
            }
            if (path[path.Length - 1] == 'n')
            {
                string Text = File.ReadAllText(path);
                figures = JsonConvert.DeserializeObject<List<Figure>>(Text);
            }
            if (path[path.Length - 1] == 'l')
            {
                XmlSerializer xml = new XmlSerializer(typeof(Figure));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    figures = (List<Figure>)xml.Deserialize(fs);
                }
            }
            return figures;
        }
        public static void Save(string path, List<Figure> figures)
        {
            int i = 0, j = 0;
            string[] text = new string[9];

            if (path[path.Length - 1] == 't')
            {
                do
                {
                    text[i] = figures[j].Name;
                    text[i + 1] = figures[j].Height.ToString();
                    text[i + 2] = figures[j].Width.ToString();
                    i += 3;
                    j++;
                } while (text.Length > i);
                File.WriteAllLines(path, text);
            }
            if (path[path.Length - 1] == 'n')
            {
                string json = JsonConvert.SerializeObject(figures);
                File.WriteAllText(path, json);
            }
            if (path[path.Length - 1] == 'l')
            {
                XmlSerializer xml = new XmlSerializer(typeof(Figure));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, figures);
                }
            }
        }
    }
}
