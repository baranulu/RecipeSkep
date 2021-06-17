using LezizTariflerSepeti.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LezizTariflerSepeti.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }




        public DbSet<Category> Categories { get; set; }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
