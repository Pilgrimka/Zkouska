using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EvidencePojistenychWebAppASP.Models;

namespace EvidencePojistenychWebAppASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EvidencePojistenychWebAppASP.Models.Pojistenec> Pojistenec { get; set; } = default!;
        public DbSet<EvidencePojistenychWebAppASP.Models.Pojisteni> Pojisteni { get; set; } = default!;
    }
}