using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class GetPerson_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPerson = @"
           CREATE PROCEDURE [dbo].[GetAllPersons]
            AS BEGIN
                SELECT * FROM [dto].[Persons]
            END

            ";
            migrationBuilder.Sql(sp_GetAllPerson);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPerson = @"
           DROP PROCEDURE [dbo].[GetAllPersons]";
            migrationBuilder.Sql(sp_GetAllPerson);
        }
    }
}
