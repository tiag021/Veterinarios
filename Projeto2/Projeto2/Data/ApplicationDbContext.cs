using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto2.Models;

namespace Projeto2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //definir tabela na base de dados

        public DbSet<Animais> Animais { get; set; }
        public DbSet<Donos> Donos { get; set; }
        public DbSet<Vets> Veterinarios { get; set; }
        public DbSet<Consultas> Consultas { get; set; }
    }
}