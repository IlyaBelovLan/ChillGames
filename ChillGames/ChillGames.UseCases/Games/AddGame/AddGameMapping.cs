namespace ChillGames.UseCases.Games.AddGame
{
    using System.Linq;
    using AutoMapper;
    using JetBrains.Annotations;
    using Models.Entities.Games;
    using Models.Entities.Tags;
    using Models.Entities.Translations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddGameMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AddGameMapping"/>.
        /// </summary>
        public AddGameMapping()
        {
            CreateMap<AddGameCommand, EntityGame>()
                .ForMember(
                    d => d.Tags,
                    o => o.MapFrom(s => s.Tags.Select(s => new EntityTag { Name = s })))
                .ForMember(
                    d => d.Translations, 
                    o => o.MapFrom(s => s.Translations.Select(s => new EntityTranslation { Language = s.Key, TranslationType = s.Value})));
        }
    }
}