using Arch.Core.Entities;
using Arch.Infra.Data.EntitiesConfiguration;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Arch.Infra.Data.Context
{
    public class ArchContext : DbContext
    {
        public ArchContext()
            : base(ConnectionString)
        {

        }

        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ArchContext"].ConnectionString;
            }
        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
            .Where(p => p.Name == p.ReflectedType.Name + "Id")
            .Configure(p => p.IsKey());

            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}