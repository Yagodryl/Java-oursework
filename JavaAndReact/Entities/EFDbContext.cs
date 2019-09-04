using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JavaAndReact.Entities
{
    public class EFDbContext : IdentityDbContext<DbUser, DbRole, long, IdentityUserClaim<long>,
    DbUserRole, IdentityUserLogin<long>,
    IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<ClientProfile> Clients { get; set; }
        public virtual DbSet<ClientOrder> ClientOrders { get; set; }
        public virtual DbSet<ClientCard> ClientCards { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }
        public virtual DbSet<SellerProfile> Sellers { get; set; }
        public virtual DbSet<SellerStorage> SellerStorages { get; set; }
        public virtual DbSet<TypeOfProduct> TypeOfProducts { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Query<BrokerProfileModel>().ToView("vBrokersProfile");

            base.OnModelCreating(builder);

            builder.Entity<DbUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
