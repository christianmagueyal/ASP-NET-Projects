using Microsoft.EntityFrameworkCore;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repository
{

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Warning> Warnings { get; set; }

    }
}
