using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Entities;

namespace TodoApp
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Node> Nodes { get; set; }
    }
}
