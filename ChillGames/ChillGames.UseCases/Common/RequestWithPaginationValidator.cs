namespace ChillGames.UseCases.Common
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class RequestWithPaginationValidator : AbstractValidator<IRequestWithPagination>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="RequestWithPaginationValidator"/>.
        /// </summary>
        public RequestWithPaginationValidator()
        {
            CascadeMode = CascadeMode.Stop;
            
            RuleFor(r => r.PageNumber)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Номер страницы не может быть меньше нуля!");

            RuleFor(r => r.PageSize)
                .GreaterThan(0)
                .WithMessage("Размер страницы не может быть меньше единицы!");
        }
    }
}