using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor_Assessment_Test
{
    public class ColorChecker : IColorManagement
    {
        public List<Person> FindPersonByColor(List<Person> persons, int colorID)
        {
            return persons.Where(p => p.Color.ID == colorID).ToList();
        }
    }
}
