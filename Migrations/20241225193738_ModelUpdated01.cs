using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBerberUygulamasi.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdated01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Customers_CustomerID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Employees_EmployeeID",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Services",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Services_EmployeeID",
                table: "Services",
                newName: "IX_Services_UserID");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Appointments",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_CustomerID",
                table: "Appointments",
                newName: "IX_Appointments_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserID",
                table: "Appointments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_UserID",
                table: "Services",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_UserID",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Services",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Services_UserID",
                table: "Services",
                newName: "IX_Services_EmployeeID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Appointments",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserID",
                table: "Appointments",
                newName: "IX_Appointments_CustomerID");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserID",
                table: "Employees",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Customers_CustomerID",
                table: "Appointments",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Employees_EmployeeID",
                table: "Services",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
