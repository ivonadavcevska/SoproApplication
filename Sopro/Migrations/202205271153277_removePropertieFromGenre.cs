namespace Sopro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePropertieFromGenre : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Genres", "Property");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Property", c => c.Int(nullable: false));
        }
    }
}
