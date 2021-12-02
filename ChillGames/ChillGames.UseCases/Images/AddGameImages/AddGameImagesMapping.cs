namespace ChillGames.UseCases.Images.AddGameImages
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using JetBrains.Annotations;
    using Models.Common.Extensions;
    using Models.Entities.Images;
    using Models.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddGameImagesMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AddGameImagesMapping"/>.
        /// </summary>
        public AddGameImagesMapping()
        {
            CreateMap<GameImageInfo, EntityGameImage>();

            CreateMap<AddGameImagesCommand, List<EntityGameImage>>()
                .ConstructUsing((s, context) => s.Images.Select(gi =>
                    {
                        var image = context.Mapper.Map<EntityGameImage>(gi);
                        image.EntityGameId = s.GameId.ToLong();
                        return image;
                    })
                    .ToList());
        }
    }
}