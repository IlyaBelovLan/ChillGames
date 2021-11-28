namespace ChillGames.UseCases.Games.UpdateGame
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="UpdateGameCommandValidator"/>.
        /// </summary>
        public UpdateGameCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Не задан идентификатор игры!");
            
            RuleFor(c => c.Price)
                .Custom((price, context) =>
                {
                    if (price != null)
                        if (price < 0)
                            context.AddFailure("Цена не может быть меньше нуля!");

                });

            RuleFor(c => c.Discount)
                .Custom((disc, context) =>
                {
                    if (disc != null)
                        if (disc < 0)
                            context.AddFailure("Скидка не может быть меньше нуля!");

                });

            RuleFor(c => c.Count)
                .Custom((count, context) =>
                {
                    if (count != null)
                        if (count < 0)
                            context.AddFailure("Количество игр не может быть меньше нуля!");

                });
        }
    }
}