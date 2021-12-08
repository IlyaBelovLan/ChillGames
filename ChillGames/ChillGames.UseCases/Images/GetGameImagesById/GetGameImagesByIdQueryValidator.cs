namespace ChillGames.UseCases.Images.GetGameImagesById
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGameImagesByIdQueryValidator : AbstractValidator<GetGameImagesByIdQuery>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGameImagesByIdQueryValidator"/>.
        /// </summary>
        public GetGameImagesByIdQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotEmpty()
                .WithMessage("Не задан идентификатор игры!");
        }
    }
}