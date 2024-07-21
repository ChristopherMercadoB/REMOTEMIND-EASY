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
        public DbSet<UserResponse> UserResponse { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            #region Tables
            model.Entity<Questions>().ToTable("Preguntas");
            model.Entity<Responses>().ToTable("Respuestas");
            model.Entity<UserResponse>().ToTable("RespuestaDeUsuario");
            #endregion

            #region Primary Keys
            model.Entity<Questions>().HasKey(e=>e.Id);
            model.Entity<Responses>().HasKey(e=>e.Id);
            model.Entity<UserResponse>().HasKey(e => new {e.ResponseId, e.QuestionId});
            #endregion

            #region Foreign Keys
            #endregion

            #region Properties
            #region Questions
            model.Entity<Questions>()
                .Property(e => e.Title)
                .IsRequired();
            #endregion

            #region Responses
            model.Entity<Responses>()
                .Property(e => e.Name)
                .IsRequired();

            model.Entity<Responses>()
                .Property(e => e.Value)
                .IsRequired();
            #endregion

            #endregion
        }
    }
}
