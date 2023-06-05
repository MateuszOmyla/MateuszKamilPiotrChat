using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Context
{
    public class ChatDbContext: DbContext
    {
        private readonly IConfiguration _config;

        public ChatDbContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<GroupMember> GroupMembers => Set<GroupMember>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<UserMessages> UserMessages => Set<UserMessages>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config.GetConnectionString("HermesContextDb"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserMessages>().
                HasKey(um => new { um.UserId, um.MessageID });
            builder.Entity<UserMessages>()
                .HasOne(um => um.Message)
                .WithMany(um => um.UserMesseges)
                .HasForeignKey(um => um.MessageID);
            builder.Entity<UserMessages>()
                .HasOne(um => um.User)
                .WithMany(um => um.RecivedMessages)
                .HasForeignKey(um => um.UserId);
        }
    }
}
