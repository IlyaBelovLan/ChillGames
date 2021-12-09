namespace ChillGames.UseCases.Users.GetUserInfo
{
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetUserInfoQueryValidator : AbstractValidator<GetUserInfoQuery>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetUserInfoQueryValidator"/>.
        /// </summary>
        public GetUserInfoQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotEmpty()
                .WithMessage("Не задан идентификатор пользователя!");
        }
    }
}