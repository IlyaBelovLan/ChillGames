namespace ChillGames.UseCases.Images.DeleteGameImages
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class DeleteGameImagesCommandValidator : AbstractValidator<DeleteGameImagesCommand>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="DeleteGameImagesCommandValidator"/>.
        /// </summary>
        public DeleteGameImagesCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;
            
            RuleFor(c => c.GameId)
                .NotEmpty()
                .WithMessage("Не задан идентификатор игры!");

            RuleFor(c => c.ImageIds)
                .NotEmpty()
                .WithMessage("Список изображений не может быть пустым!");

            RuleForEach(c => c.ImageIds)
                .NotEmpty()
                .WithMessage("Идентификатор изображения не может быть пустым!");
        }
    }
}