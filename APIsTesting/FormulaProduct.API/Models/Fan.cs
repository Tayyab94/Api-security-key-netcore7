using System.ComponentModel.DataAnnotations;

namespace FormulaProduct.API.Models
{
    public class Fan
    {
        public int Id { get; set; }

        public string employee_name { get; set; } = String.Empty;
        public double employee_salary { get;set; }

        public int employee_age { get; set; } 
        public string profile_image { get; set; } = String.Empty;
    }
}
