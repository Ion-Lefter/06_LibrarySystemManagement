using LibraryDomain;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryData
{
    public class AddStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE SearchBooksByAuthor
            @Author NVARCHAR(255)
            AS
            BEGIN
            SELECT
                li.Id,
                li.Title,
                li.Author,
                li.YearPublished,
                b.ISBN
            FROM
                LibraryItems li
            INNER JOIN
                Books b ON li.Id = b.Id
            WHERE
                li.Author LIKE '%' + @Author + '%';
                    END
                    GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE dbo.SearchBooksByAuthor");
        }


    }
}
