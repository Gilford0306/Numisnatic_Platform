

namespace Numisnatic_Platform.Class
{
    public class Log
    {
        public int Id { get; set; }
        public string Date  { get; set; }
        public string Description { get; set; }


        public Log()
        {

        }

        public Log(int id, string date, string description)
        { 

            Id = id;
            Date = date;
            Description = description;
        }

    }
}
