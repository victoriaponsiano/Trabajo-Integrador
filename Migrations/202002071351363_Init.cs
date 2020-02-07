
namespace Trabajo_Integrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pregunta_Examen", newName: "ExamenPreguntas");
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuarios", "Administrador", c => c.Boolean(nullable: false));
            DropColumn("dbo.Usuarios", "Aministrador");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Aministrador", c => c.Boolean(nullable: false));
            DropColumn("dbo.Usuarios", "Administrador");
            DropTable("dbo.Logs");
            RenameTable(name: "dbo.ExamenPreguntas", newName: "Pregunta_Examen");
        }
    }
}
