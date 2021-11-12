namespace ChillGames.UseCases.GetGameById
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using JetBrains.Annotations;
    using Models.Common;
    using Models.Entities.Games;
    using Models.Games;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGameByIdMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGameByIdMapping"/>.
        /// </summary>
        public GetGameByIdMapping()
        {
            CreateMap<EntityGame, Game>()
                .ForMember(
                    d => d.Id,
                    o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(
                    d => d.Translations,
                    o => o.MapFrom(s => 
                        s.Translations.Select(st => 
                            new KeyValuePair<string, TranslationType> (st.Language, st.TranslationType))))
                .ForMember(
                    d => d.Tags, 
                    o => o.MapFrom(s => s.Tags.Select(st => st.Name)));
        }
    }
}