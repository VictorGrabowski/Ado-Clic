using Microsoft.EntityFrameworkCore;

namespace Ado_Clic.Data
{
    public class BeneficiaryDbContext : DbContext
    {
        public BeneficiaryDbContext (DbContextOptions<BeneficiaryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ado_Clic.Models.Beneficiary> Beneficiary => Set<Ado_Clic.Models.Beneficiary>();
    }
}