namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.StudentCourses", new[] { "Student_ID" });
            AddColumn("dbo.Students", "Name", c => c.String());
            CreateIndex("dbo.StudentCourses", "Student_Id");
            DropColumn("dbo.Students", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "FirstName", c => c.String());
            DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            DropColumn("dbo.Students", "Name");
            CreateIndex("dbo.StudentCourses", "Student_ID");
        }
    }
}
