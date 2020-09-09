using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class NodeUpdateModel
    {
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
    }
}
