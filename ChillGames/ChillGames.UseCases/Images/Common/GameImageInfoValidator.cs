namespace ChillGames.UseCases.Images.Common
{
    using FluentValidation;
    using JetBrains.Annotations;
    using Models.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GameImageInfoValidator : AbstractValidator<GameImageInfo>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameImageInfoValidator"/>.
        /// </summary>
        public GameImageInfoValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(g => g.ImageCode)
                .Must(m => !string.IsNullOrEmpty(m))
                .WithMessage("Код изображения не может быть пустым!");
        }
    }
}