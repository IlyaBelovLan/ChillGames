namespace ChillGames.UseCases.Images.GetGamePreview
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetGamePreviewQueryValidator : AbstractValidator<GetGamePreviewQuery>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetGamePreviewQueryValidator"/>.
        /// </summary>
        public GetGamePreviewQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotEmpty()
                .WithMessage("Не задан идентификатор игры!");
        }
    }
}