using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.LibraryCodeFirstEntity
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
    }
}

