using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Todo
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int TodoId { get; set; }

        public List<Tag> Tags { get; set; }
        
        public Boolean Active { get; set; }
    }
}
