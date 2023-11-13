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
                Email="demo@gmail.com",
                Name="demo1"
            },

            new Fan()
            {
                Id=2,
                Email="donled@gmail.com",
                Name="donled"
            },
        };
    }
}
