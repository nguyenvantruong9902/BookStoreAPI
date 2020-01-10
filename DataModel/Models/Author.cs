using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Author : Base
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public DateTime Birthday { get; set; }
        public string Cover { get; set; }
        public List<Book> Books { get; set; }
    }
}
