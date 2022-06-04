using Microsoft.EntityFrameworkCore;
using Prieto_T3.WEB.BD.Mapping;
using Prieto_T3.WEB.Models;

namespace Prieto_T3.WEB.BD
{
    public class DbEntities : DbContext
    {
        public DbSet<HistoriaClinica> Historias { get; set; }
        public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HistoriaMapping());
        }
        //public static List<HistoriaClinica> Historias = new List<HistoriaClinica>();

        public static List<Usuario> Usuarios = new()
        {
            new Usuario { Id = 1, Username = "admin", Password = "123456" },
            new Usuario { Id = 2, Username = "user1", Password = "123456" },
            new Usuario { Id = 3, Username = "user2", Password = "123456" },
        };
    }
}
