using Microsoft.EntityFrameworkCore;
using StarWars.Api.DataLayer.Entities;

namespace StarWars.Api.DataLayer
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext(DbContextOptions<StarWarsContext> options) : base(options) 
        {
        }
        public DbSet<Film> Films { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<FilmCharacterLink> FilmCharacterLink { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var films = new Film[] 
            { 
                new Film{ Id = Guid.Parse("720733c0-8327-40aa-ba24-0ee67c273fe1"), Name = "Звёздные войны. Эпизод I: Скрытая угроза", ReleaseDate = new DateTime(1999, 7, 29)},
                new Film{ Id = Guid.Parse("1f90431e-2189-464f-944d-0258da70deb6"), Name = "Звёздные войны. Эпизод II: Атака клонов", ReleaseDate = new DateTime(2002, 5, 16)},
                new Film{ Id = Guid.Parse("6f68aca3-0ce7-4cdd-9c0c-cc097aa42ad5"), Name = "Звёздные войны. Эпизод 3: Месть ситхов", ReleaseDate = new DateTime(2020, 6, 6)},
                new Film{ Id = Guid.Parse("34c4ac65-be5e-4bd6-86c3-06f4a7598253"), Name = "Звёздные войны: Пробуждение Силы", ReleaseDate = new DateTime(2015, 12, 17)},
                new Film{ Id = Guid.Parse("bc33071f-7241-4594-9d6c-2b58afdc5f31"), Name = "Изгой-один: Звёздные войны. Истории", ReleaseDate = new DateTime(2016, 12, 15)},
                new Film{ Id = Guid.Parse("7b1e26ed-2548-4e3f-ae5d-6610c69dd3cf"), Name = "Звёздные войны: Последние джедаи", ReleaseDate = new DateTime(2017, 12, 14)},
                new Film{ Id = Guid.Parse("899573e9-8bb6-492f-806e-fa48d23b58e3"), Name = "Хан Соло: Звёздные Войны. Истории", ReleaseDate = new DateTime(2018, 5, 24)},
                new Film{ Id = Guid.Parse("73aadd9f-821c-4720-97eb-edf5b597f7b7"), Name = "Звёздные войны: Скайуокер. Восход", ReleaseDate = new DateTime(2019, 12, 19)},
            };

            var characters = new Character[]
            {
                new Character
                {
                    Id = Guid.Parse("41150197-125a-46af-b160-8b191d3fbf93"),
                    Name = "Энакин Скайуокер",
                    OriginalName = "Anakin Skywalker",
                    Description = "Служил Галактической Республике как рыцарь-джедай, позже служил Галактической Империи и командовавший её войсками, как Лорд ситхов Дарт Вейдер. Рождённый Шми Скайуокер, в юности стал тайным мужем сенатора с Набу, Падме Амидалы Наберри. Он был отцом гранд-мастера Люка Скайуокера, рыцаря-джедая Леи Органы-Соло и дедом Бена Скайуокера. Хотя, будучи взрослым, Энакин стал ключевой фигурой в Галактике, не смотря на низкое происхождение. Первые годы своей жизни он провёл на Татуине вместе со своей матерью в качестве раба.",
                    BirthYearBBY = 42,
                    HeightMeters = 1.88f,
                    HairColor = "Русый",
                    EyeColor = "Голубой",
                    Gender = Gender.Male,
                    OriginPlanetName = "Татуин",
                    Race = "Человек"
                },
                new Character
                {
                    Id = Guid.Parse("bbdc11bf-e583-4314-ab17-29782e804557"),
                    Name = "Палпатин",
                    OriginalName = "Palpatine",
                    Description = "Могущественный тёмный лорд ситхов, который, благодаря собственной хитрости и интригам сделал себе головокружительную политическую карьеру, став, в конечном итоге, последним Верховным канцлером Республики и первым императором Галактической Империи. Это был, пожалуй, один из наиболее могущественнейших, если, не самый могущественный, адепт Тёмной стороны, обладавший поистине колоссальной мощью: его не смогли убить ни Мейс Винду, ни Йода, ни Гален Марек ни многие, многие другие джедаи и противники. Он был тёмным лордом ситхов, который придерживался Правила двух, правила Ордена лордов ситхов и был самым успешным и влиятельным ситхом, которого когда-либо знала Галактика, сумевшим воплотить в жизнь Великий план и уничтожить как Орден джедаев, так и саму Республику, став единоличным и безоговорочным повелителем всей Галактики. ",
                    BirthYearBBY = 82,
                    HeightMeters = 1.73f,
                    HairColor = "Рыжий",
                    EyeColor = "Голубой",
                    Gender = Gender.Male,
                    OriginPlanetName = "Набу",
                    Race = "Человек"
                }
            };

            modelBuilder.Entity<FilmCharacterLink>().HasData(new FilmCharacterLink[]
            {
                new FilmCharacterLink
                {
                    CharacterId = Guid.Parse("bbdc11bf-e583-4314-ab17-29782e804557"),
                    FilmId = Guid.Parse("720733c0-8327-40aa-ba24-0ee67c273fe1")
                },
                new FilmCharacterLink
                {
                    CharacterId = Guid.Parse("bbdc11bf-e583-4314-ab17-29782e804557"),
                    FilmId = Guid.Parse("1f90431e-2189-464f-944d-0258da70deb6")
                },
                new FilmCharacterLink
                {
                    CharacterId = Guid.Parse("bbdc11bf-e583-4314-ab17-29782e804557"),
                    FilmId = Guid.Parse("6f68aca3-0ce7-4cdd-9c0c-cc097aa42ad5")
                },

                new FilmCharacterLink
                {
                    CharacterId = Guid.Parse("41150197-125a-46af-b160-8b191d3fbf93"),
                    FilmId = Guid.Parse("720733c0-8327-40aa-ba24-0ee67c273fe1")
                },
                new FilmCharacterLink
                {
                    CharacterId = Guid.Parse("41150197-125a-46af-b160-8b191d3fbf93"),
                    FilmId = Guid.Parse("1f90431e-2189-464f-944d-0258da70deb6")
                },
                new FilmCharacterLink
                {
                    CharacterId = Guid.Parse("41150197-125a-46af-b160-8b191d3fbf93"),
                    FilmId = Guid.Parse("6f68aca3-0ce7-4cdd-9c0c-cc097aa42ad5")
                },
            });

            modelBuilder.Entity<Film>().HasData(films);

            modelBuilder.Entity<Character>().HasData(characters);
        }
    }
}
