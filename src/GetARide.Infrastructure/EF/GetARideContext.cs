using GetARide.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace GetARide.Infrastructure.EF
{
    public class GetARideContext : DbContext
    {
        private readonly SqlSettings _sqlSettings;
        public DbSet<User> Users {get;set;}
        public GetARideContext(DbContextOptions<GetARideContext> options, SqlSettings sqlSettings) : base(options)
        {
            _sqlSettings = sqlSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_sqlSettings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase("GetARide");
                return;
            }
            optionsBuilder.UseSqlServer(_sqlSettings.ConnectionString);
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            var userBuilder = modelBuilder.Entity<User>();
            userBuilder.HasKey( x => x.Id);
         }
    }
}