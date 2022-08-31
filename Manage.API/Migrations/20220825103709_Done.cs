using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manage.API.Migrations
{
    public partial class Done : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hu_allowance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_allowance", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_bank",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_bank", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_contract",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    number_of_month = table.Column<int>(type: "int", nullable: true),
                    money = table.Column<double>(type: "float", nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_contract", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_hospital",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_hospital", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_nation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_nation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_org_title",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrgId = table.Column<int>(type: "int", nullable: true),
                    title_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_org_title", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_organization",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    order_number = table.Column<int>(type: "int", nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_organization", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_welface",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_welface", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "other_list_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_other_list_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Se_User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    access_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refresh_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expired_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Se_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_bank_branch",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    bank_id = table.Column<int>(type: "int", nullable: false),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_bank_branch", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_bank_branch_hu_bank_bank_id",
                        column: x => x.bank_id,
                        principalTable: "hu_bank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hu_Contract_allowance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    contract_id = table.Column<int>(type: "int", nullable: true),
                    allwance_id = table.Column<int>(type: "int", nullable: true),
                    money = table.Column<double>(type: "float", nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_Contract_allowance", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_Contract_allowance_hu_allowance_allwance_id",
                        column: x => x.allwance_id,
                        principalTable: "hu_allowance",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_Contract_allowance_hu_contract_contract_id",
                        column: x => x.contract_id,
                        principalTable: "hu_contract",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_province",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    nation_id = table.Column<int>(type: "int", nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_province", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_province_hu_nation_nation_id",
                        column: x => x.nation_id,
                        principalTable: "hu_nation",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_contractual_benefits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    contract_id = table.Column<int>(type: "int", nullable: true),
                    welface_id = table.Column<int>(type: "int", nullable: true),
                    money = table.Column<double>(type: "float", nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_contractual_benefits", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_contractual_benefits_hu_contract_contract_id",
                        column: x => x.contract_id,
                        principalTable: "hu_contract",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_contractual_benefits_hu_welface_welface_id",
                        column: x => x.welface_id,
                        principalTable: "hu_welface",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "other_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_other_list", x => x.id);
                    table.ForeignKey(
                        name: "FK_other_list_other_list_type_type_id",
                        column: x => x.type_id,
                        principalTable: "other_list_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_district",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    province_id = table.Column<int>(type: "int", nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_district", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_district_hu_province_province_id",
                        column: x => x.province_id,
                        principalTable: "hu_province",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_title",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    group_id = table.Column<int>(type: "int", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_title", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_title_other_list_group_id",
                        column: x => x.group_id,
                        principalTable: "other_list",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_ward",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    distric_id = table.Column<int>(type: "int", nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_ward", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_ward_hu_district_distric_id",
                        column: x => x.distric_id,
                        principalTable: "hu_district",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    EmployeeCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    join_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    work_status = table.Column<bool>(type: "bit", nullable: true),
                    contract_id = table.Column<int>(type: "int", nullable: true),
                    title_id = table.Column<int>(type: "int", nullable: true),
                    working_id = table.Column<int>(type: "int", nullable: true),
                    direct_manager = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    itime_id = table.Column<int>(type: "int", nullable: true),
                    last_working_id = table.Column<int>(type: "int", nullable: true),
                    last_working_day = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_employee_hu_contract_contract_id",
                        column: x => x.contract_id,
                        principalTable: "hu_contract",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_employee_hu_org_title_org_id",
                        column: x => x.org_id,
                        principalTable: "hu_org_title",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_employee_hu_organization",
                        column: x => x.org_id,
                        principalTable: "hu_organization",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_employee_hu_title_title_id",
                        column: x => x.title_id,
                        principalTable: "hu_title",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_employee_cv",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birth_day = table.Column<DateTime>(type: "datetime", nullable: true),
                    birth_place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    marital_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    religion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nation_id = table.Column<int>(type: "int", nullable: true),
                    per_province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    per_district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    per_ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    per_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    navprovice = table.Column<string>(name: "nav-provice", type: "nvarchar(max)", nullable: true),
                    nav_district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nav_ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nav_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_no = table.Column<int>(type: "int", nullable: true),
                    id_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    visa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    visa_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    visa_place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    work_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank_id = table.Column<int>(type: "int", nullable: true),
                    bank_brank_id = table.Column<int>(type: "int", nullable: true),
                    hospital_id = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_employee_cv", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_employee_cv_hu_bank",
                        column: x => x.bank_id,
                        principalTable: "hu_bank",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_employee_cv_hu_bank_branch",
                        column: x => x.bank_brank_id,
                        principalTable: "hu_bank_branch",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_employee_cv_hu_employee",
                        column: x => x.employee_id,
                        principalTable: "hu_employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_employee_cv_hu_hospital",
                        column: x => x.hospital_id,
                        principalTable: "hu_hospital",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_employee_cv_hu_nation",
                        column: x => x.nation_id,
                        principalTable: "hu_nation",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_employee_education",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    fisrt_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    finsish_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    activeflg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_employee_education", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_employee_education_hu_employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "hu_employee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_employee_family",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    relation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_no = table.Column<int>(type: "int", nullable: true),
                    is_deduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deduct_from = table.Column<DateTime>(type: "datetime", nullable: true),
                    deduct_to = table.Column<DateTime>(type: "datetime", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_employee_family", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_employee_family_hu_employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "hu_employee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_salary_records",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    contrac_id = table.Column<int>(type: "int", nullable: true),
                    contract_allwance_id = table.Column<int>(type: "int", nullable: true),
                    contract_welface_id = table.Column<int>(type: "int", nullable: true),
                    money = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_salary_records", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_salary_records_hu_Contract_allowance_contract_allwance_id",
                        column: x => x.contract_allwance_id,
                        principalTable: "hu_Contract_allowance",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_salary_records_hu_contract_contrac_id",
                        column: x => x.contrac_id,
                        principalTable: "hu_contract",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_salary_records_hu_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "hu_employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_hu_salary_records_hu_welface_contract_welface_id",
                        column: x => x.contract_welface_id,
                        principalTable: "hu_welface",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hu_shools",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    from_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    to_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    year_gra = table.Column<int>(type: "int", nullable: true),
                    schools = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    certificate_from_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    certificate_todate = table.Column<DateTime>(type: "datetime", nullable: true),
                    train_form = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_shools", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_shools_hu_employee",
                        column: x => x.employee_id,
                        principalTable: "hu_employee",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Se_User",
                columns: new[] { "id", "Activeflg", "code", "created_by", "created_time", "last_update_time", "last_updated_by", "Password", "Role", "Username", "access_token", "expired_time", "refresh_token" },
                values: new object[] { -1, "SuperActive", "UE00-1", "SuperAdmin", new DateTime(2022, 8, 25, 10, 37, 9, 281, DateTimeKind.Utc).AddTicks(5863), new DateTime(2022, 8, 25, 10, 37, 9, 281, DateTimeKind.Utc).AddTicks(5872), "SuperAdmin", "831171121011146510010910511064495051", "SuperAdmin", "SuperAdmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_hu_bank_branch_bank_id",
                table: "hu_bank_branch",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_Contract_allowance_allwance_id",
                table: "hu_Contract_allowance",
                column: "allwance_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_Contract_allowance_contract_id",
                table: "hu_Contract_allowance",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_contractual_benefits_contract_id",
                table: "hu_contractual_benefits",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_contractual_benefits_welface_id",
                table: "hu_contractual_benefits",
                column: "welface_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_district_province_id",
                table: "hu_district",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_contract_id",
                table: "hu_employee",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_org_id",
                table: "hu_employee",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_title_id",
                table: "hu_employee",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_cv_bank_brank_id",
                table: "hu_employee_cv",
                column: "bank_brank_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_cv_bank_id",
                table: "hu_employee_cv",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_cv_employee_id",
                table: "hu_employee_cv",
                column: "employee_id",
                unique: true,
                filter: "[employee_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_cv_hospital_id",
                table: "hu_employee_cv",
                column: "hospital_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_cv_nation_id",
                table: "hu_employee_cv",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_education_employee_id",
                table: "hu_employee_education",
                column: "employee_id",
                unique: true,
                filter: "[employee_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_education_employee_id1",
                table: "hu_employee_education",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_family_employee_id",
                table: "hu_employee_family",
                column: "employee_id",
                unique: true,
                filter: "[employee_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_hu_family_employee_id",
                table: "hu_employee_family",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_province_nation_id",
                table: "hu_province",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_salary_records_contrac_id",
                table: "hu_salary_records",
                column: "contrac_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_salary_records_contract_allwance_id",
                table: "hu_salary_records",
                column: "contract_allwance_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_salary_records_contract_welface_id",
                table: "hu_salary_records",
                column: "contract_welface_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_salary_records_employee_id",
                table: "hu_salary_records",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_hu_salary_records_EmployeeId",
                table: "hu_salary_records",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_hu_shools_employee_id",
                table: "hu_shools",
                column: "employee_id",
                unique: true,
                filter: "[employee_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_hu_title_group_id",
                table: "hu_title",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_ward_distric_id",
                table: "hu_ward",
                column: "distric_id");

            migrationBuilder.CreateIndex(
                name: "IX_other_list_type_id",
                table: "other_list",
                column: "type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hu_contractual_benefits");

            migrationBuilder.DropTable(
                name: "hu_employee_cv");

            migrationBuilder.DropTable(
                name: "hu_employee_education");

            migrationBuilder.DropTable(
                name: "hu_employee_family");

            migrationBuilder.DropTable(
                name: "hu_salary_records");

            migrationBuilder.DropTable(
                name: "hu_shools");

            migrationBuilder.DropTable(
                name: "hu_ward");

            migrationBuilder.DropTable(
                name: "Se_User");

            migrationBuilder.DropTable(
                name: "hu_bank_branch");

            migrationBuilder.DropTable(
                name: "hu_hospital");

            migrationBuilder.DropTable(
                name: "hu_Contract_allowance");

            migrationBuilder.DropTable(
                name: "hu_welface");

            migrationBuilder.DropTable(
                name: "hu_employee");

            migrationBuilder.DropTable(
                name: "hu_district");

            migrationBuilder.DropTable(
                name: "hu_bank");

            migrationBuilder.DropTable(
                name: "hu_allowance");

            migrationBuilder.DropTable(
                name: "hu_contract");

            migrationBuilder.DropTable(
                name: "hu_org_title");

            migrationBuilder.DropTable(
                name: "hu_organization");

            migrationBuilder.DropTable(
                name: "hu_title");

            migrationBuilder.DropTable(
                name: "hu_province");

            migrationBuilder.DropTable(
                name: "other_list");

            migrationBuilder.DropTable(
                name: "hu_nation");

            migrationBuilder.DropTable(
                name: "other_list_type");
        }
    }
}
