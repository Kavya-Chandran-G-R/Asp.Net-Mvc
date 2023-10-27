using Login.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Login.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Register> Registers { get; set; }
        public DbSet<LoginDTO> LoginDTOs { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
