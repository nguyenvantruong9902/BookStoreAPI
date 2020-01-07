using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Book : Base
    {
        public Book()
        {
            this.Category = new HashSet<Category>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Year { get; set; }
        public virtual Author Author { get; set; }
        public string Publisher { get; set; }
        public string Cover { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}
