namespace ChillGames.UseCases.Images.UpdateGameImages
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class UpdateGameImagesCommandValidator : AbstractValidator<UpdateGameImagesCommand>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="UpdateGameImagesCommandValidator"/>.
        /// </summary>
        public UpdateGameImagesCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;
            
            RuleFor(c => c.GameId)
                .NotEmpty()
                .WithMessage("Не задан идентификатор игры!");

            RuleForEach(c => c.Images)
                .Must(m => !string.IsNullOrEmpty(m.Id))
                .WithMessage("Не задан идентификатор изображения!");
        }
    }
}