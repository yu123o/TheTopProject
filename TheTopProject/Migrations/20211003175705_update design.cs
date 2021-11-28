using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTopProject.Migrations
{
    public partial class updatedesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    Image = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    DateofAdd = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Subject = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Message = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Approve = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    number = table.Column<int>(nullable: false),
                    balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CreditCa__FD291E40AAF6BB8E", x => x.number);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Subject = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    RegistrationTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    JobTitle = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DepartmentName = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    StartWorkTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebSiteInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    SmallDescription = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    Image = table.Column<string>(unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSiteInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Design",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Image = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    CategroyId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Design", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Design__Categroy__34C8D9D1",
                        column: x => x.CategroyId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Design__Customer__35BCFE0A",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detuction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detuction", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Detuction__Custo__4316F928",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    LoginTime = table.Column<TimeSpan>(nullable: false),
                    LogoutTime = table.Column<TimeSpan>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendence", x => x.Id);
                    table.ForeignKey(
                        name: "FK__EmployeeA__Emplo__2F10007B",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "date", nullable: false),
                    EndTime = table.Column<DateTime>(type: "date", nullable: false),
                    NewCost = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    DesignId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Offer__DesignId__403A8C7D",
                        column: x => x.DesignId,
                        principalTable: "Design",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReviewText = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    CompanyRatio = table.Column<double>(nullable: false),
                    DesignId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Review__Customer__3D5E1FD2",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Review__DesignId__3C69FB99",
                        column: x => x.DesignId,
                        principalTable: "Design",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyRatio = table.Column<double>(nullable: false),
                    DesignId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Sales__CustomerI__398D8EEE",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Sales__DesignId__38996AB5",
                        column: x => x.DesignId,
                        principalTable: "Design",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Admin__A9D1053467E6A0C5",
                table: "Admin",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__A9D105348274F8D2",
                table: "Customer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Design_CategroyId",
                table: "Design",
                column: "CategroyId");

            migrationBuilder.CreateIndex(
                name: "IX_Design_CustomerId",
                table: "Design",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Detuction_CustomerId",
                table: "Detuction",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__A9D10534D11EC192",
                table: "Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendence_EmployeeId",
                table: "EmployeeAttendence",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_DesignId",
                table: "Offer",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_CustomerId",
                table: "Review",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_DesignId",
                table: "Review",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DesignId",
                table: "Sales",
                column: "DesignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "Detuction");

            migrationBuilder.DropTable(
                name: "EmployeeAttendence");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "WebSiteInfo");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Design");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
