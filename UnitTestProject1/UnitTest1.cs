using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Assecor_Assessment_Test;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestReadFile()
        {
            FileAccessor fa = new FileAccessor();
            List<Person> check = new List<Person>();
            List<ColorData> colors = new List<ColorData>()
            {
                new ColorData() { ID = 1, Name = "blau"},
                  new ColorData() { ID = 2, Name = "grün"},
                    new ColorData() { ID = 3, Name = "violett"},
                      new ColorData() { ID = 4, Name = "rot"},
                        new ColorData() { ID = 5, Name = "gelb"},
                        new ColorData() { ID = 6, Name = "türkis"},
                        new ColorData() { ID = 7, Name = "weiß"},
            };
            check.Add(new Person() { LastName = "Müller", Name = "Hans", Zipcode = "67742", City = "Lauterecken", Color = colors.First(p => p.ID == 1) });
            check[check.Count - 1].Color = colors.Find(p => p.ID == 1);

            check.Add(new Person() { LastName = "Petersen", Name = "Peter", Zipcode = "18439", City = "Stralsund", Color = colors.First(p => p.ID == 2) });
            check.Add(new Person() { LastName = "Johnson", Name = "Johnny", Zipcode = "88888", City = "made up", Color = colors.First(p => p.ID == 3) });
            check.Add(new Person() { LastName = "Millenium", Name = "Milly", Zipcode = "77777", City = "made up too", Color = colors.First(p => p.ID == 4) });
            check.Add(new Person() { LastName = "Müller", Name = "Jonas", Zipcode = "32323", City = "Hansstadt", Color = colors.First(p => p.ID == 5) });
            check.Add(new Person() { LastName = "Fujitsu", Name = "Tastatur", Zipcode = "42342", City = "Japan", Color = colors.First(p => p.ID == 6) });
            check.Add(new Person() { LastName = "Bart", Name = "Bertram" });
            check.Add(new Person() { LastName = "12313 Wasweißich", Name = "1" });
            check.Add(new Person() { LastName = "Gerber", Name = "Gerda", Zipcode = "76535", City = "Woanders", Color = colors.First(p => p.ID == 3) });
            check.Add(new Person() { LastName = "Klaussen", Name = "Klaus", Zipcode = "43246", City = "Hierach", Color = colors.First(p => p.ID == 2) });

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            fa.SourcePath = fa.DestPath = projectDirectory;
            fa.SourcePath += "\\sample-input.csv";
            fa.DestPath += "\\output.json";

            var persons = fa.ReadFile();
            bool pass = true;
            TestResult tr = new TestResult();

            for (int i = 0; i < check.Count; i++)
            {
                pass &= (persons[i].LastName == check[i].LastName && persons[i].Name == check[i].Name && persons[i].Zipcode == check[i].Zipcode
                    && persons[i].City == check[i].City && persons[i].Color == check[i].Color);
            }

            if (pass)
            {
                tr.Outcome = UnitTestOutcome.Passed;
            }
            else
            {
                tr.Outcome = UnitTestOutcome.Failed;
            }

        }

        [TestMethod]
        public void TestWriteFile()
        {
            FileAccessor fa = new FileAccessor();
            List<Person> check = new List<Person>();
            List<ColorData> colors = new List<ColorData>()
            {
                new ColorData() { ID = 1, Name = "blau"},
                  new ColorData() { ID = 2, Name = "grün"},
                    new ColorData() { ID = 3, Name = "violett"},
                      new ColorData() { ID = 4, Name = "rot"},
                        new ColorData() { ID = 5, Name = "gelb"},
                        new ColorData() { ID = 6, Name = "türkis"},
                        new ColorData() { ID = 7, Name = "weiß"},
            };
            check.Add(new Person() { LastName = "Müller", Name = "Hans", Zipcode = "67742", City = "Lauterecken", Color = colors.First(p => p.ID == 1) });
            check[check.Count - 1].Color = colors.Find(p => p.ID == 1);

            check.Add(new Person() { LastName = "Petersen", Name = "Peter", Zipcode = "18439", City = "Stralsund", Color = colors.First(p => p.ID == 2) });
            check.Add(new Person() { LastName = "Johnson", Name = "Johnny", Zipcode = "88888", City = "made up", Color = colors.First(p => p.ID == 3) });
            check.Add(new Person() { LastName = "Millenium", Name = "Milly", Zipcode = "77777", City = "made up too", Color = colors.First(p => p.ID == 4) });
            check.Add(new Person() { LastName = "Müller", Name = "Jonas", Zipcode = "32323", City = "Hansstadt", Color = colors.First(p => p.ID == 5) });
            check.Add(new Person() { LastName = "Fujitsu", Name = "Tastatur", Zipcode = "42342", City = "Japan", Color = colors.First(p => p.ID == 6) });
            check.Add(new Person() { LastName = "Bart", Name = "Bertram" });
            check.Add(new Person() { LastName = "12313 Wasweißich", Name = "1" });
            check.Add(new Person() { LastName = "Gerber", Name = "Gerda", Zipcode = "76535", City = "Woanders", Color = colors.First(p => p.ID == 3) });
            check.Add(new Person() { LastName = "Klaussen", Name = "Klaus", Zipcode = "43246", City = "Hierach", Color = colors.First(p => p.ID == 2) });

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            fa.SourcePath = fa.DestPath = projectDirectory;
            fa.SourcePath += "\\sample-input.csv";
            fa.DestPath += "\\output.json";
            
        }
    }
}
