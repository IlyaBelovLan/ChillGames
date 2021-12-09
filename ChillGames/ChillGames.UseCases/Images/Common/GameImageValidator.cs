namespace ChillGames.UseCases.Images.Common
{
    using FluentValidation;
    using JetBrains.Annotations;
    using Models.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GameImageValidator : AbstractValidator<GameImage>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameImageValidator"/>.
        /// </summary>
        public GameImageValidator()
        {
            CascadeMode = CascadeMode.Stop;
            
            Include(new GameImageInfoValidator());
            
            RuleFor(g => g.Id)
                .NotEmpty()
                .WithMessage("Не задан идентификатор изображения!");

            RuleFor(g => g.GameId)
                .NotEmpty()
                .WithMessage("Не задан идентификатор игры!");
        }
    }
}