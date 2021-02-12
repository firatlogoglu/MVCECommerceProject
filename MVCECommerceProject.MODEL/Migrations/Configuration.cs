namespace MVCECommerceProject.MODEL.Migrations
{
    using MVCECommerceProject.MODEL.Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCECommerceProject.MODEL.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVCECommerceProject.MODEL.Context.ProjectContext context)
        {
            SampleData data = new SampleData();
            data.InitializeDatabase(context);
        }
    }
}