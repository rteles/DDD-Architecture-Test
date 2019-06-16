namespace Arch.Infra.Data.Migrations
{
    internal sealed class Configuration : System.Data.Entity.Migrations.DbMigrationsConfiguration<Arch.Infra.Data.Context.ArchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Arch.Infra.Data.Context.ArchContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.User.Add(new Arch.Core.Entities.User()
            //{
            //    Name = "Roger",
            //    LastName = "Teles",
            //    Email = "roger@teste.com.br",
            //    BirthDate = new System.DateTime(1987, 08, 12),
            //    Active = true
            //});
        }
    }
}