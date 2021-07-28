using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assecor_Assessment_Test
{
    public class FileAccessor : IFileAccess
    {
        public string SourcePath { get; set; }
        public string DestPath { get; set; }
        List<ColorData> colors;

        public FileAccessor()
        {
            colors = new List<ColorData>()
            {
                new ColorData() { ID = 1, Name = "blau"},
                  new ColorData() { ID = 2, Name = "grün"},
                    new ColorData() { ID = 3, Name = "violett"},
                      new ColorData() { ID = 4, Name = "rot"},
                        new ColorData() { ID = 5, Name = "gelb"},
                        new ColorData() { ID = 6, Name = "türkis"},
                        new ColorData() { ID = 7, Name = "weiß"},
            };
        }

        public List<Person> ReadFile()
        {
            List<Person> persons = new List<Person>();

            List<string> text = File.ReadAllLines(SourcePath).ToList();

            for (int i = 0; i < text.Count; i++)
            {
                List<string> data = text[i].Split(',').ToList();

                Person p = new Person();
                p.ID = i;
                if (data.Count > 0)
                {
                    p.LastName = data[0];
                }
                if (data.Count > 1)
                {
                    p.LastName = data[1];
                }
                if (data.Count > 2)
                {
                    p.Name = data[2];
                }
                if (data.Count > 3)
                {
                    string address = data[3];
                    p.Zipcode = address.Substring(address.IndexOf(' ')).Trim();
                    p.City = address.Substring(p.Zipcode.Length + 1);
                }
                if (data.Count > 4)
                {
                    if (int.TryParse(data[3], out int check))
                    {
                        p.Color = colors.Where(c => c.ID == int.Parse(data[3])).First();
                    }
                }
                persons.Add(p);
            }

            return persons;
        }

        public void WriteFile(List<Person> persons)
        {
            string result = "[";

            for (int i = 0; i < persons.Count; i++)
            {
                string txt = "{\r\n\"id\" : " + persons[i].ID.ToString() + ",\r\n";
                txt += "\"name\" : \"" + persons[i].Name + "\",\r\n";
                txt += "\"lastname\" : \"" + persons[i].LastName + "\",\r\n";
                txt += "\"zipcode\" : \"" + persons[i].Zipcode + "\",\r\n";
                txt += "\"city\" : \"" + persons[i].City + "\",\r\n";
                txt += "\"color\" : \"" + persons[i].Color.Name + "\",\r\n";
                txt += "\r\n}";
                if (i != persons.Count-1)
                {
                    txt += ",";
                }
            }
            result += "]";
            File.WriteAllText(DestPath, result);
        }
    }
}
