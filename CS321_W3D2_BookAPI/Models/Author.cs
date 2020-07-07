using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D2_BookAPI.Models
{
    public class Author
    {
        internal int Id;

        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
