namespace AudioProntuario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Timers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Audio", "duracao", c => c.String());
            AddColumn("dbo.Audio", "horario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Audio", "horario");
            DropColumn("dbo.Audio", "duracao");
        }
    }
}
