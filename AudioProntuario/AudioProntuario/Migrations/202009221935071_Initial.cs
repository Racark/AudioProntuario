namespace AudioProntuario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audio",
                c => new
                    {
                        idAudio = c.Int(nullable: false, identity: true),
                        AudioProntuario = c.String(),
                    })
                .PrimaryKey(t => t.idAudio);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Audio");
        }
    }
}
