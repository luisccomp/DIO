using DIO.Series.Enums;

namespace DIO.Series.Models
{
    public class Serie : BaseModel
    {
        public Genre Genre { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Serie(Id={Id}, Genre={Genre}, Title=\"{Title}\", Description=\"{Description}\", Year={Year})";
        }
    }
}