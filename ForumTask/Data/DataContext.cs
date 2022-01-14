using ForumTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTask.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
   
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

    }
}
