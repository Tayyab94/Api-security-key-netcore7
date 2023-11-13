using FormulaProduct.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProduct.XunitTest.Fixtures
{
    public class FansFixtures
    {
        public static List<Fan> GetFans() => new()
        {
            new Fan()
            {
                Id=1,
               employee_name= "Tiger Nixon",
      employee_salary= 320800,
      employee_age= 61,
      profile_image= ""
            },

            new Fan()
            {
                Id=2,
               employee_name= "Garrett Winters\"",
      employee_salary= 170750,
      employee_age= 64,
      profile_image= ""
            },
        };
    }
}
