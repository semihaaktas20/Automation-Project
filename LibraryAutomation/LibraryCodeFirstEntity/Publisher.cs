using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.LibraryCodeFirstEntity
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string PublisherName { get; set; }   
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
