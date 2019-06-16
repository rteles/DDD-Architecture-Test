namespace Arch.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUserActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Active", c => c.Boolean(nullable: false));
            DropColumn("dbo.User", "Ative");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Ative", c => c.Boolean(nullable: false));
            DropColumn("dbo.User", "Active");
        }
    }
}
