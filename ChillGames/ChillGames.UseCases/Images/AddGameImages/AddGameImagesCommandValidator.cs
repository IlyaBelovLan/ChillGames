namespace ChillGames.UseCases.Images.AddGameImages
{
    using System.Linq;
    using Common;
    using FluentValidation;
    using JetBrains.Annotations;
    using Models.Common.Extensions;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddGameImagesCommandValidator : AbstractValidator<AddGameImagesCommand>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AddGameImagesCommandValidator"/>.
        /// </summary>
        public AddGameImagesCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(c => c.Images)
                .SetValidator(new GameImageInfoListValidator());
        }
        
    }
}