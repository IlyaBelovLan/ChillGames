namespace ChillGames.UseCases.Images.UpdateGameImages
{
    using AutoMapper;
    using JetBrains.Annotations;
    using Models.Entities.Images;
    using Models.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class UpdateGameImagesMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="UpdateGameImagesMapping"/>.
        /// </summary>
        public UpdateGameImagesMapping()
        {
            CreateMap<EntityGameImage, EntityGameImage>();
            
            CreateMap<GameImage, EntityGameImage>()
                .ForMember(d => d.EntityGameId, o => o.MapFrom(s => s.GameId))
                .ForMember(d => d.ImageCode, o =>
                {
                    o.PreCondition(s => s.ImageCode != null);
                    o.MapFrom(s => s.ImageCode);
                })
                .ForMember(d => d.IsPreview, o =>
                {
                    o.PreCondition(s => s.IsPreview != null);
                    o.MapFrom(s => s.IsPreview);
                })
                .ForMember(d => d.Order, o =>
                {
                    o.PreCondition(s => s.Order != null);
                    o.MapFrom(s => s.Order);
                });
        }
    }
}