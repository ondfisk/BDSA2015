namespace BDSA2015.Lecture03.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BDSA2015.Lecture03.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BDSA2015.Lecture03.ShopContext";
        }

        protected override void Seed(BDSA2015.Lecture03.ShopContext context)
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

            var category = new Category { Name = "Cars" };
            context.Categories.AddOrUpdate(c => c.Name, category);

            context.Products.AddOrUpdate(c => c.Name,
                    new Product { Name = "BMW", Category = category, Price = 200000m },
                    new Product { Name = "VW", Category = category, Price = 100000m },
                    new Product { Name = "Mercedes", Category = category, Price = 300000m }
                );
        }
    }
}
