using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.LibraryCodeFirstEntity
{
    public class Book
    {
        [Key]
        public  int Id { get; set; }
        public string BookName { get; set; }
        public string Pages { get; set; }
        public string Language { get; set; }
        public string Edition { get; set; }
        public string Author { get; set; }
    }
}
