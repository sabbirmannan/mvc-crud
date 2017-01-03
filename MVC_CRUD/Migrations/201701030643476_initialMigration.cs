namespace MVC_CRUD.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Phone = c.String(),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Email = c.String(),
                    Department = c.Int(nullable: false),
                    Gender = c.Int(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
