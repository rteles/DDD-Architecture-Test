namespace Arch.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Ative", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Ative");
        }
    }
}
