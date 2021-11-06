namespace ChillGames.WebApi
{
    using System;
    using System.Linq;
    using Data.StoreContext;
    using Models.Common;
    using Models.Entities.Games;
    using Models.Entities.Tags;
    using Models.Entities.Translation;

    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Games.Any())
            {
                return;
            }

            var translations = new[]
            {
                new EntityTranslation
                {
                    Language = "ru",
                    TranslationType = TranslationType.InterfaceVoiceover
                }
            };
            
            context.Translations.AddRange(translations);
            context.SaveChanges();

            var tags = new[]
            {
                new EntityTag
                {
                    Name = "Одиночная игра"
                },
                new EntityTag
                {
                    Name = "Открытый мир"
                }
            };
            
            context.Tags.AddRange(tags);
            context.SaveChanges();

            /*var games = new EntityGame[]
            {
                new EntityGame
                {
                    Title = "Skyrim",
                    Description = "Beautiful RPG",
                    Price = 1000,
                    Discount = 0,
                    Platforms = new[] { Platform.Windows },
                    Launchers = new[] { Launcher.Steam },
                    Genre = "RPG",
                    Publisher = "Bethesda",
                    Translations = new[]
                    {
                        new EntityGameTranslation
                        {
                            EntityTranslationID = context.Translations.First().EntityTranslationID,
                        }
                    },
                    
                    ReleaseDate = new DateTime(2011, 11, 11),
                    
                    Tags = new[]
                    {
                        new EntityTagging
                        {
                            EntityTagID = context.Tags.ToList()[0].EntityTagID
                        },
                        new EntityTagging
                        {
                            EntityTagID = context.Tags.ToList()[1].EntityTagID
                        },
                    },
                    
                    Count = 123
                }
            };
            
            context.Games.AddRange(games);
            context.SaveChanges();*/
        }
    }
}