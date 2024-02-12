using System.ComponentModel.DataAnnotations;

namespace VersioningAPIs.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // This will include Exclude the 0 and 60, mean if the user will enter 0 or greater than equal to 60 then will get error
        [Range(0,60, MinimumIsExclusive = true, MaximumIsExclusive =true)]
        public int Age { get; set; }

        [AllowedValues("Islamabad","Karachi","Murree")]
        [DeniedValues("Lahore")]
        public string favoritePlaces {  get; set; }
    }
}
