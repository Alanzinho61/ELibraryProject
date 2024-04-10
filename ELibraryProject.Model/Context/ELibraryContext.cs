using ELibraryProject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryProject.Model.Context
{
    public class ELibraryContext : DbContext
    {
        public ELibraryContext(DbContextOptions<ELibraryContext> dbContextOptions) : base(dbContextOptions) 
        { 
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}
