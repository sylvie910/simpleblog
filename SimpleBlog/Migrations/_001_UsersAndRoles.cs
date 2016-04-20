using System;
using System.Data;
using FluentMigrator;

namespace SimpleBlog.Migrations
{
    [Migration(1)]
    //for sorting purposes
    public class _001_UsersAndRoles : Migration
    {
        public override void Down()
        {
            //role_users表必须先删除，因为它对users表和roles表有外键依赖
            Delete.Table("role_users");
            Delete.Table("roles");
            Delete.Table("users");
        }

        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("username").AsString(128)
                .WithColumn("email").AsCustom("NVARCHAR(256)")
                .WithColumn("password_hash").AsString(128);
            Create.Table("roles")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(128);
            Create.Table("role_users")
                .WithColumn("user_id").AsInt32().ForeignKey("users", "id").OnDelete(Rule.Cascade)
                .WithColumn("role_id").AsInt32().ForeignKey("roles", "id").OnDelete(Rule.Cascade);
        }
    }
}