using ApoioConsultorio.Models;
using Microsoft.EntityFrameworkCore;

namespace ApoioConsultorio.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }

        


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }

        public DbSet<Procedimento>Procedimentos { get; set; }
        public DbSet<ImpostoTaxa> ImpostoTaxas { get; set; }
    }
}
