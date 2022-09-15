namespace CleanArchitecture.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            DropColumn("dbo.Employees", "DepId");
            RenameColumn(table: "dbo.Employees", name: "Department_Id", newName: "DepId");
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Employees", "DepId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DepId");
            AddForeignKey("dbo.Employees", "DepId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepId" });
            AlterColumn("dbo.Employees", "DepId", c => c.Int());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String());
            RenameColumn(table: "dbo.Employees", name: "DepId", newName: "Department_Id");
            AddColumn("dbo.Employees", "DepId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Department_Id");
            AddForeignKey("dbo.Employees", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
