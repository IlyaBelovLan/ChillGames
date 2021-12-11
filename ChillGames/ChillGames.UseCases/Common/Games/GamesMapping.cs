namespace ChillGames.UseCases.Common.Games
{
    using System.Linq;
    using AutoMapper;
    using JetBrains.Annotations;
    using Models.Common;
    using Models.Common.Extensions;
    using Models.Entities.Games;
    using Models.Entities.Tags;
    using Models.Entities.Translations;
    using Models.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GamesMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GamesMapping"/>.
        /// </summary>
        public GamesMapping()
        {
            CreateMap<EntityGame, Game>()
                .ForMember(
                    d => d.Id,
                    o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(
                    d => d.Translations,
                    o => o.MapFrom(s => 
                        s.Translations.Select(st => 
                            new KeyValue<string, TranslationType> (st.Language, st.TranslationType))))
                .ForMember(
                    d => d.Tags, 
                    o => o.MapFrom(s => s.Tags.Select(st => st.Name)));
            
            CreateMap<Game, EntityGame>()
                .ForMember(
                    d => d.Id,
                    o => o.MapFrom(s => s.Id.ToLong()))
                .ForMember(
                    d => d.Translations,
                    o => o.MapFrom(s => 
                        s.Translations.Select(st => new EntityTranslation
                        {
                            Language = st.Key,
                            TranslationType = st.Value
                        })))
                .ForMember(
                    d => d.Tags, 
                    o => o.MapFrom(s => s.Tags.Select(st => new EntityTag
                    {
                        Name = st
                    })));
        }
    }
}