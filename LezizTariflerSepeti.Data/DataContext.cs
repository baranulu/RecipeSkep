using LezizTariflerSepeti.Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LezizTariflerSepeti.Data
{
    public class DataContext : IdentityDbContext<MyUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }




        public DbSet<Category> Categories { get; set; }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<MyUser> MyUsers { get; set; }
    }
}
