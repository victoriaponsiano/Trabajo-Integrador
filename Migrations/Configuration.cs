﻿namespace Trabajo_Integrador.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Trabajo_Integrador.EntityFramework.TrabajoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Trabajo_Integrador.EntityFramework.TrabajoDbContext";
        }

        protected override void Seed(Trabajo_Integrador.EntityFramework.TrabajoDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
