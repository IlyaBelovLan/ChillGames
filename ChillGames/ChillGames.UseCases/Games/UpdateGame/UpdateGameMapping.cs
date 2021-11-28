namespace ChillGames.UseCases.Games.UpdateGame
{
    using System.Linq;
    using AutoMapper;
    using Common.Extensions;
    using JetBrains.Annotations;
    using Models.Entities.Games;
    using Models.Entities.Tags;
    using Models.Entities.Translations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class UpdateGameMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="UpdateGameMapping"/>.
        /// </summary>
        public UpdateGameMapping()
        {
            CreateMap<UpdateGameCommand, EntityGame>()
                .ForMember(d => d.Title, o =>
                {
                    o.PreCondition(s => s.Title != null);
                    o.MapFrom(s => s.Title);
                })
                .ForMember(d => d.Description, o =>
                {
                    o.PreCondition(s => s.Description != null);
                    o.MapFrom(s => s.Description);
                })
                .ForMember(d => d.Price, o =>
                {
                    o.PreCondition(s => s.Price != null);
                    o.MapFrom(s => s.Price);
                })
                .ForMember(d => d.Discount, o =>
                {
                    o.PreCondition(s => s.Discount != null);
                    o.MapFrom(s => s.Discount);
                })
                .ForMember(d => d.Platforms, o =>
                {
                    o.PreCondition(s => !s.Platforms.IsNullOrEmpty());
                    o.MapFrom(s => s.Platforms);
                })
                .ForMember(d => d.Launchers, o =>
                {
                    o.PreCondition(s => !s.Launchers.IsNullOrEmpty());
                    o.MapFrom(s => s.Launchers);
                })
                .ForMember(d => d.Genre, o =>
                {
                    o.PreCondition(s => s.Genre != null);
                    o.MapFrom(s => s.Genre);
                })
                .ForMember(d => d.Publisher, o =>
                {
                    o.PreCondition(s => s.Publisher != null);
                    o.MapFrom(s => s.Publisher);
                })
                .ForMember(d => d.ReleaseDate, o =>
                {
                    o.PreCondition(s => s.ReleaseDate != null);
                    o.MapFrom(s => s.ReleaseDate);
                })
                .ForMember(d => d.Count, o =>
                {
                    o.PreCondition(s => s.Count != null);
                    o.MapFrom(s => s.Count);
                })
                .ForMember(
                    d => d.Tags,
                    o =>
                    {
                        o.PreCondition(s => !s.Tags.IsNullOrEmpty());
                        o.MapFrom(s => s.Tags.Select(et => new EntityTag { Name = et }));
                    })
                .ForMember(
                    d => d.Translations,
                    o =>
                    {
                        o.PreCondition(s => !s.Translations.IsNullOrEmpty());
                        o.MapFrom(s => s.Translations.Select(et => new EntityTranslation { Language = et.Key, TranslationType = et.Value}));
                    });
        }
    }
}