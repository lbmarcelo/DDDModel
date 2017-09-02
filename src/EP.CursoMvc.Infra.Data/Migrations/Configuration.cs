using System.Data.Entity.Migrations;
using EP.CursoMvc.Infra.Data.Context;

namespace EP.CursoMvc.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CursoMvcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CursoMvcContext context)
        {
        }
    }
}