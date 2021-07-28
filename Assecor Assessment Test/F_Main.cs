using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assecor_Assessment_Test
{
    public partial class F_Main : Form
    {
        public F_Main()
        {
            InitializeComponent();

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
            Person p1 = new Person()
            {
                LastName = "Müller",
                Name = "Hans",
                Zipcode = "67742",
                City = "Lauterecken",
                Color = colors.First(p => p.ID == 1)
            };

            //Person p1 = new Person()
            //{
            //    LastName = "Müller",
            //    Name = "Hans",
            //    Zipcode = "67742",
            //    City = "Lauterecken",
            //};
            //var where = colors.Where(c => c.ID == 1);
        }
    }
}
