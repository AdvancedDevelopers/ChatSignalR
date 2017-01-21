namespace Codefirst_Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAttributesOfMessage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Body", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Body", c => c.String());
        }
    }
}
