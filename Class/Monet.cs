using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numisnatic_Platform.Class
{
    public class Monet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
        public bool IsSelling { get; set; }


        public Monet()
        {

        }

        public Monet(int id, string title, int price, int userId, bool isSelling)
        {
            Id = id;
            Title = title;
            Price = price;
            UserId = userId;
            IsSelling = isSelling;
        }

    }
}
