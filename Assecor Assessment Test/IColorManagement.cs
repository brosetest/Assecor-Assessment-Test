using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor_Assessment_Test
{
    public interface IColorManagement
    {
        List<Person> FindPersonByColor(List<Person> persons, int colorID);
    }
}
