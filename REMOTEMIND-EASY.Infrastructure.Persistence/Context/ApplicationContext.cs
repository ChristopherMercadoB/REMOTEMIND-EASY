using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Core.Domain.Common;
using REMOTEMIND_EASY.Core.Domain.Entities;


namespace REMOTEMIND_EASY.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> op) : base(op)
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
        public DbSet<Result> Results { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            #region Tables
            model.Entity<Questions>().ToTable("Preguntas");
            model.Entity<Responses>().ToTable("Respuestas");
            model.Entity<UserResponse>().ToTable("RespuestaDeUsuario");
            model.Entity<Result>().ToTable("Resultado");
            model.Entity<User>().ToTable("Usuario");
            model.Entity<Role>().ToTable("Rol");
            model.Entity<Comment>().ToTable("Comentarios");
            #endregion

            #region Primary Keys
            model.Entity<Questions>().HasKey(e => e.Id);
            model.Entity<Responses>().HasKey(e => e.Id);
            model.Entity<UserResponse>().HasKey(e => e.Id);
            model.Entity<UserResponse>().HasKey(e => e.Id);
            model.Entity<User>().HasKey(e => e.Id);
            model.Entity<Role>().HasKey(e => e.Id);
            model.Entity<Comment>().HasKey(e => e.Id);
            #endregion

            #region Foreign Keys
            model.Entity<Questions>()
                .HasMany<UserResponse>(u => u.UserResponses)
                .WithOne(u => u.Question)
                .HasForeignKey(u => u.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Responses>()
                .HasMany<UserResponse>(u => u.UserResponses)
                .WithOne(u => u.Response)
                .HasForeignKey(u => u.ResponseId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Role>()
                .HasMany(u => u.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            model.Entity<User>()
                .HasMany(u => u.Results)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            model.Entity<User>()
                .HasMany(u=>u.Comments)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
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
            #region Result
            model.Entity<Result>()
                .Property(e => e.Name)
                .IsRequired();
            #endregion
            #region User
            model.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired();

                entity.Property(e => e.Username)
                .IsRequired();

                entity.Property(e => e.Password)
                .IsRequired();

              
            });
            #endregion
            #endregion
        }
    }
}
