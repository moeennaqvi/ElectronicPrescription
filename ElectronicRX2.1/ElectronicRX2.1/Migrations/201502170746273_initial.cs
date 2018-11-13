namespace ElectronicRX2._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "OverrideWarning", c => c.Boolean(nullable: false));
            AddColumn("dbo.Prescriptions", "OverrideReason", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prescriptions", "OverrideReason");
            DropColumn("dbo.Prescriptions", "OverrideWarning");
        }
    }
}
