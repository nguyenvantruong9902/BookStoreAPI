using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Category : Base
    {
        public Category()
        {
            this.Book = new HashSet<Book>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Book> Book { get; set; }
    }
}
