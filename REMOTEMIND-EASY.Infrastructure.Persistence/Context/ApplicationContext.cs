using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Core.Domain.Common;
using REMOTEMIND_EASY.Core.Domain.Entities;


namespace REMOTEMIND_EASY.Infrastructure.Persistence.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> op):base(op)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedBy = "REMOTEMIND-EASY";
                        item.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        item.Entity.UpdatedBy = "REMOTEMIND-EASY";
                        item.Entity.UpdatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Questions> Questions { get; set; }
        public DbSet<Responses> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            #region Tables
            #endregion

            #region Primary Keys
            #endregion

            #region Foreign Keys
            #endregion

            #region Properties
            #endregion
        }
    }
}
