using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StarWars.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    OriginalName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    BirthYearBBY = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Race = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    HeightMeters = table.Column<float>(type: "REAL", nullable: false),
                    HairColor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    EyeColor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    OriginPlanetName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmCharacterLink",
                columns: table => new
                {
                    CharacterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FilmId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCharacterLink", x => new { x.CharacterId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_FilmCharacterLink_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCharacterLink_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "BirthYearBBY", "Description", "EyeColor", "Gender", "HairColor", "HeightMeters", "Name", "OriginPlanetName", "OriginalName", "Race" },
                values: new object[,]
                {
                    { new Guid("41150197-125a-46af-b160-8b191d3fbf93"), 42, "Служил Галактической Республике как рыцарь-джедай, позже служил Галактической Империи и командовавший её войсками, как Лорд ситхов Дарт Вейдер. Рождённый Шми Скайуокер, в юности стал тайным мужем сенатора с Набу, Падме Амидалы Наберри. Он был отцом гранд-мастера Люка Скайуокера, рыцаря-джедая Леи Органы-Соло и дедом Бена Скайуокера. Хотя, будучи взрослым, Энакин стал ключевой фигурой в Галактике, не смотря на низкое происхождение. Первые годы своей жизни он провёл на Татуине вместе со своей матерью в качестве раба.", "Голубой", 0, "Русый", 1.88f, "Энакин Скайуокер", "Татуин", "Anakin Skywalker", "Человек" },
                    { new Guid("bbdc11bf-e583-4314-ab17-29782e804557"), 82, "Могущественный тёмный лорд ситхов, который, благодаря собственной хитрости и интригам сделал себе головокружительную политическую карьеру, став, в конечном итоге, последним Верховным канцлером Республики и первым императором Галактической Империи. Это был, пожалуй, один из наиболее могущественнейших, если, не самый могущественный, адепт Тёмной стороны, обладавший поистине колоссальной мощью: его не смогли убить ни Мейс Винду, ни Йода, ни Гален Марек ни многие, многие другие джедаи и противники. Он был тёмным лордом ситхов, который придерживался Правила двух, правила Ордена лордов ситхов и был самым успешным и влиятельным ситхом, которого когда-либо знала Галактика, сумевшим воплотить в жизнь Великий план и уничтожить как Орден джедаев, так и саму Республику, став единоличным и безоговорочным повелителем всей Галактики. ", "Голубой", 0, "Рыжий", 1.73f, "Палпатин", "Набу", "Palpatine", "Человек" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("1f90431e-2189-464f-944d-0258da70deb6"), "Звёздные войны. Эпизод II: Атака клонов", new DateTime(2002, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("34c4ac65-be5e-4bd6-86c3-06f4a7598253"), "Звёздные войны: Пробуждение Силы", new DateTime(2015, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f68aca3-0ce7-4cdd-9c0c-cc097aa42ad5"), "Звёздные войны. Эпизод 3: Месть ситхов", new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("720733c0-8327-40aa-ba24-0ee67c273fe1"), "Звёздные войны. Эпизод I: Скрытая угроза", new DateTime(1999, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("73aadd9f-821c-4720-97eb-edf5b597f7b7"), "Звёздные войны: Скайуокер. Восход", new DateTime(2019, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7b1e26ed-2548-4e3f-ae5d-6610c69dd3cf"), "Звёздные войны: Последние джедаи", new DateTime(2017, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("899573e9-8bb6-492f-806e-fa48d23b58e3"), "Хан Соло: Звёздные Войны. Истории", new DateTime(2018, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bc33071f-7241-4594-9d6c-2b58afdc5f31"), "Изгой-один: Звёздные войны. Истории", new DateTime(2016, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FilmCharacterLink",
                columns: new[] { "CharacterId", "FilmId" },
                values: new object[,]
                {
                    { new Guid("41150197-125a-46af-b160-8b191d3fbf93"), new Guid("1f90431e-2189-464f-944d-0258da70deb6") },
                    { new Guid("41150197-125a-46af-b160-8b191d3fbf93"), new Guid("6f68aca3-0ce7-4cdd-9c0c-cc097aa42ad5") },
                    { new Guid("41150197-125a-46af-b160-8b191d3fbf93"), new Guid("720733c0-8327-40aa-ba24-0ee67c273fe1") },
                    { new Guid("bbdc11bf-e583-4314-ab17-29782e804557"), new Guid("1f90431e-2189-464f-944d-0258da70deb6") },
                    { new Guid("bbdc11bf-e583-4314-ab17-29782e804557"), new Guid("6f68aca3-0ce7-4cdd-9c0c-cc097aa42ad5") },
                    { new Guid("bbdc11bf-e583-4314-ab17-29782e804557"), new Guid("720733c0-8327-40aa-ba24-0ee67c273fe1") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmCharacterLink_FilmId",
                table: "FilmCharacterLink",
                column: "FilmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmCharacterLink");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
