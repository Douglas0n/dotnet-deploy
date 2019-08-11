using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class NomesContext : DbContext
    {
        public NomesContext(DbContextOptions<NomesContext> options)
            : base(options)
        { }

        public DbSet<Nomes> Nomes { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=dbo.Nomes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }*/
    }
}