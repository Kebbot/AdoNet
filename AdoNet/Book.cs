using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet
{
    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }
}
