namespace ChillGames.UseCases.Games.DeleteGameById
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class DeleteGameByIdCommandValidator : AbstractValidator<DeleteGameByIdCommand>
    {
        public DeleteGameByIdCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Не задан идентификатор игры!");
        }
    }
}