namespace PosturerAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Status", c => c.String());
            DropColumn("dbo.AspNetUsers", "IsDoctor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsDoctor", c => c.Boolean());
            DropColumn("dbo.AspNetUsers", "Status");
        }
    }
}
