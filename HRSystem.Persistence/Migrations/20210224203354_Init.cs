using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRSystem.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                schema: "HR",
                columns: table => new
                {
                    AddressTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.AddressTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                schema: "HR",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "HR",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                schema: "HR",
                columns: table => new
                {
                    EmailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EmailTypeID = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.EmailID);
                });

            migrationBuilder.CreateTable(
                name: "EmailTypes",
                schema: "HR",
                columns: table => new
                {
                    EmailTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTypes", x => x.EmailTypeID);
                });

            migrationBuilder.CreateTable(
                name: "LogEmployees",
                schema: "HR",
                columns: table => new
                {
                    LogEmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    ShiftID = table.Column<int>(type: "int", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: true),
                    TeamMemberPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteColorID = table.Column<int>(type: "int", nullable: false),
                    PreferredPhoneID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEmployees", x => x.LogEmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "HR",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "HR",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneTypes",
                schema: "HR",
                columns: table => new
                {
                    PhoneTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneTypes", x => x.PhoneTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "HR",
                columns: table => new
                {
                    PositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                schema: "HR",
                columns: table => new
                {
                    ShiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "HR",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "HR",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    AddressTypeID = table.Column<int>(type: "int", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    City = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    State = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressTypes_AddressTypeID",
                        column: x => x.AddressTypeID,
                        principalSchema: "HR",
                        principalTable: "AddressTypes",
                        principalColumn: "AddressTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                schema: "HR",
                columns: table => new
                {
                    PhoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    PhoneTypeID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.PhoneID);
                    table.ForeignKey(
                        name: "FK_Phones_PhoneTypes_PhoneTypeID",
                        column: x => x.PhoneTypeID,
                        principalSchema: "HR",
                        principalTable: "PhoneTypes",
                        principalColumn: "PhoneTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "HR",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    ShiftID = table.Column<int>(type: "int", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: true),
                    TeamMemberPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteColorID = table.Column<int>(type: "int", nullable: false),
                    PreferredPhoneID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Colors_FavoriteColorID",
                        column: x => x.FavoriteColorID,
                        principalSchema: "HR",
                        principalTable: "Colors",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "HR",
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerID",
                        column: x => x.ManagerID,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Phones_PreferredPhoneID",
                        column: x => x.PreferredPhoneID,
                        principalSchema: "HR",
                        principalTable: "Phones",
                        principalColumn: "PhoneID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionID",
                        column: x => x.PositionID,
                        principalSchema: "HR",
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Shifts_ShiftID",
                        column: x => x.ShiftID,
                        principalSchema: "HR",
                        principalTable: "Shifts",
                        principalColumn: "ShiftID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalSchema: "HR",
                        principalTable: "Statuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationEmployee",
                schema: "HR",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationEmployee", x => new { x.NotificationID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_NotificationEmployee_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationEmployee_Notifications_NotificationID",
                        column: x => x.NotificationID,
                        principalSchema: "HR",
                        principalTable: "Notifications",
                        principalColumn: "NotificationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionEmployee",
                schema: "HR",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionEmployee", x => new { x.PermissionID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_PermissionEmployee_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "HR",
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionEmployee_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalSchema: "HR",
                        principalTable: "Permissions",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressTypeID",
                schema: "HR",
                table: "Addresses",
                column: "AddressTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_Name",
                schema: "HR",
                table: "AddressTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_Name",
                schema: "HR",
                table: "Colors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                schema: "HR",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmailAddress",
                schema: "HR",
                table: "Emails",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailTypes_Name",
                schema: "HR",
                table: "EmailTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                schema: "HR",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FavoriteColorID",
                schema: "HR",
                table: "Employees",
                column: "FavoriteColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerID",
                schema: "HR",
                table: "Employees",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionID",
                schema: "HR",
                table: "Employees",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PreferredPhoneID",
                schema: "HR",
                table: "Employees",
                column: "PreferredPhoneID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShiftID",
                schema: "HR",
                table: "Employees",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StatusID",
                schema: "HR",
                table: "Employees",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationEmployee_EmployeeID",
                schema: "HR",
                table: "NotificationEmployee",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionEmployee_EmployeeID",
                schema: "HR",
                table: "PermissionEmployee",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneTypeID",
                schema: "HR",
                table: "Phones",
                column: "PhoneTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneTypes_Name",
                schema: "HR",
                table: "PhoneTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name",
                schema: "HR",
                table: "Positions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_Name",
                schema: "HR",
                table: "Shifts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_Name",
                schema: "HR",
                table: "Statuses",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Emails",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "EmailTypes",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "LogEmployees",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "NotificationEmployee",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "PermissionEmployee",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "AddressTypes",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Colors",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Phones",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Shifts",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "PhoneTypes",
                schema: "HR");
        }
    }
}
