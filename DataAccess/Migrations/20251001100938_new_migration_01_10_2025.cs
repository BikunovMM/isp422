using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class new_migration_01_10_2025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ПараметрКонвертации",
                columns: table => new
                {
                    IDПараметраКонвертации = table.Column<long>(type: "bigint", nullable: false),
                    Название = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ПараметрКонвертации", x => x.IDПараметраКонвертации);
                });

            migrationBuilder.CreateTable(
                name: "ПараметрыКонвертации",
                columns: table => new
                {
                    IDПараметраКонвертации = table.Column<long>(type: "bigint", nullable: false),
                    Значение = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ПараметрыКонвертации", x => x.IDПараметраКонвертации);
                });

            migrationBuilder.CreateTable(
                name: "Роли",
                columns: table => new
                {
                    IDРоли = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Роли__22FFC98EB699A054", x => x.IDРоли);
                });

            migrationBuilder.CreateTable(
                name: "Файлы",
                columns: table => new
                {
                    IDФайла = table.Column<int>(type: "int", nullable: false),
                    НазваниеФайла = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    IDФормата = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Файлы__DC2A4F00A787B3C7", x => x.IDФайла);
                });

            migrationBuilder.CreateTable(
                name: "ФорматыФайлов",
                columns: table => new
                {
                    IDФормата = table.Column<int>(type: "int", nullable: false),
                    Название = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ФорматыФ__479E4A84968FED91", x => x.IDФормата);
                });

            migrationBuilder.CreateTable(
                name: "Пользователи",
                columns: table => new
                {
                    IDПользователя = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDРоли = table.Column<int>(type: "int", nullable: false),
                    Логин = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Пароль = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    АдресЭлектроннойПочты = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ДатаРегистрации = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Пользова__B58D26DAE60FCCE0", x => x.IDПользователя);
                    table.ForeignKey(
                        name: "FK__Пользоват__IDРол__571DF1D5",
                        column: x => x.IDРоли,
                        principalTable: "Роли",
                        principalColumn: "IDРоли");
                });

            migrationBuilder.CreateTable(
                name: "Конвертации",
                columns: table => new
                {
                    IDКонвертации = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDВходногоФайла = table.Column<int>(type: "int", nullable: false),
                    IDВыходногоФайла = table.Column<int>(type: "int", nullable: false),
                    IDПараметровКонвертации = table.Column<long>(type: "bigint", nullable: true),
                    ДатаКонвертации = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Конверта__3ABF9A5D1587A147", x => x.IDКонвертации);
                    table.ForeignKey(
                        name: "FK__Конвертац__IDВхо__52593CB8",
                        column: x => x.IDВходногоФайла,
                        principalTable: "Файлы",
                        principalColumn: "IDФайла");
                    table.ForeignKey(
                        name: "FK__Конвертац__IDВых__5441852A",
                        column: x => x.IDВыходногоФайла,
                        principalTable: "Файлы",
                        principalColumn: "IDФайла");
                });

            migrationBuilder.CreateTable(
                name: "ИспользованиеФорматов",
                columns: table => new
                {
                    IDИспользованияФорматов = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDПользователя = table.Column<int>(type: "int", nullable: false),
                    IDФормата = table.Column<int>(type: "int", nullable: false),
                    КоличествоИспользований = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Использо__9171285F3195ED75", x => x.IDИспользованияФорматов);
                    table.ForeignKey(
                        name: "FK__Использов__IDПол__4E88ABD4",
                        column: x => x.IDПользователя,
                        principalTable: "Пользователи",
                        principalColumn: "IDПользователя");
                    table.ForeignKey(
                        name: "FK__Использов__IDФор__4F7CD00D",
                        column: x => x.IDФормата,
                        principalTable: "ФорматыФайлов",
                        principalColumn: "IDФормата");
                });

            migrationBuilder.CreateTable(
                name: "Настройки",
                columns: table => new
                {
                    IDНастроек = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDПользователя = table.Column<int>(type: "int", nullable: false),
                    Язык = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Уведомления = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Настройк__11166FF5D815ECC8", x => x.IDНастроек);
                    table.ForeignKey(
                        name: "FK__Настройки__IDПол__5629CD9C",
                        column: x => x.IDПользователя,
                        principalTable: "Пользователи",
                        principalColumn: "IDПользователя");
                });

            migrationBuilder.CreateTable(
                name: "ИсторияКонвертаций",
                columns: table => new
                {
                    IDИсторииКонвертаций = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDПользователя = table.Column<int>(type: "int", nullable: false),
                    IDКонвертации = table.Column<int>(type: "int", nullable: false),
                    IDПараметровКонвертации = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ИсторияК__D63642FB00768E2C", x => x.IDИсторииКонвертаций);
                    table.ForeignKey(
                        name: "FK__ИсторияКо__IDКон__5070F446",
                        column: x => x.IDКонвертации,
                        principalTable: "Конвертации",
                        principalColumn: "IDКонвертации");
                    table.ForeignKey(
                        name: "FK__ИсторияКо__IDПол__5165187F",
                        column: x => x.IDПользователя,
                        principalTable: "Пользователи",
                        principalColumn: "IDПользователя");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ИспользованиеФорматов_IDПользователя",
                table: "ИспользованиеФорматов",
                column: "IDПользователя");

            migrationBuilder.CreateIndex(
                name: "IX_ИспользованиеФорматов_IDФормата",
                table: "ИспользованиеФорматов",
                column: "IDФормата");

            migrationBuilder.CreateIndex(
                name: "IX_ИсторияКонвертаций_IDКонвертации",
                table: "ИсторияКонвертаций",
                column: "IDКонвертации");

            migrationBuilder.CreateIndex(
                name: "IX_ИсторияКонвертаций_IDПользователя",
                table: "ИсторияКонвертаций",
                column: "IDПользователя");

            migrationBuilder.CreateIndex(
                name: "IX_Конвертации_IDВходногоФайла",
                table: "Конвертации",
                column: "IDВходногоФайла");

            migrationBuilder.CreateIndex(
                name: "IX_Конвертации_IDВыходногоФайла",
                table: "Конвертации",
                column: "IDВыходногоФайла");

            migrationBuilder.CreateIndex(
                name: "IX_Настройки_IDПользователя",
                table: "Настройки",
                column: "IDПользователя");

            migrationBuilder.CreateIndex(
                name: "IX_Пользователи_IDРоли",
                table: "Пользователи",
                column: "IDРоли");

            migrationBuilder.CreateIndex(
                name: "UQ__Пользова__130C4ECF13F3C291",
                table: "Пользователи",
                column: "Пароль",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Пользова__BC2217D33F4B4A9A",
                table: "Пользователи",
                column: "Логин",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Роли__38DA80358CE0501A",
                table: "Роли",
                column: "Название",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__ФорматыФ__38DA8035A12B6CC9",
                table: "ФорматыФайлов",
                column: "Название",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ИспользованиеФорматов");

            migrationBuilder.DropTable(
                name: "ИсторияКонвертаций");

            migrationBuilder.DropTable(
                name: "Настройки");

            migrationBuilder.DropTable(
                name: "ПараметрКонвертации");

            migrationBuilder.DropTable(
                name: "ПараметрыКонвертации");

            migrationBuilder.DropTable(
                name: "ФорматыФайлов");

            migrationBuilder.DropTable(
                name: "Конвертации");

            migrationBuilder.DropTable(
                name: "Пользователи");

            migrationBuilder.DropTable(
                name: "Файлы");

            migrationBuilder.DropTable(
                name: "Роли");
        }
    }
}
