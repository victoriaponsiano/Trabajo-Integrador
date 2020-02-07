namespace Trabajo_Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaMigracion2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PreguntaExamen", newName: "Pregunta_Examen");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Pregunta_Examen", newName: "PreguntaExamen");
        }
    }
}
