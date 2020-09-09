using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Entities
{
    public class Node
    {
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        [Required]
        [StringLength(50)]       
        public string Task { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
    }
}
