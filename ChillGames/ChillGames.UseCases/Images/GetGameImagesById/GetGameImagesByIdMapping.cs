namespace ChillGames.UseCases.Images.GetGameImagesById
{
    using AutoMapper;
    using JetBrains.Annotations;
    using Models.Entities.Images;
    using Models.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGameImagesByIdMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGameImagesByIdMapping"/>.
        /// </summary>
        public GetGameImagesByIdMapping()
        {
            CreateMap<EntityGameImage, GameImage>()
                .ForMember(d => d.GameId, o => o.MapFrom(s => s.EntityGameId));
        }
    }
}