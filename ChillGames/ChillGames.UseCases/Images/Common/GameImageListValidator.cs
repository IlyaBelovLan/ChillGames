namespace ChillGames.UseCases.Images.Common
{
    using System.Collections.Generic;
    using FluentValidation;
    using JetBrains.Annotations;
    using Models.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GameImageListValidator : AbstractValidator<IEnumerable<GameImage>>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameImageListValidator"/>.
        /// </summary>
        public GameImageListValidator()
        {
            CascadeMode = CascadeMode.Stop;
            
            RuleForEach(l => l)
                .SetValidator(new GameImageValidator());
        }
    }
}