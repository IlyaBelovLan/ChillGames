namespace ChillGames.UseCases.Users.AddUser
{
    using Data.StoreContext;
    using FluentValidation;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AddUserCommandValidator"/>.
        /// </summary>
        public AddUserCommandValidator(StoreDbContext dbContext)
        {
            CascadeMode = CascadeMode.Stop;
            
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Не задано имя пользователя!");

            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("Неверный формат электронной почты!");

            RuleFor(c => c.Email)
                .CustomAsync(async (email, validationContext, cancellationToken) =>
                {
                    var user = await dbContext.Users.FirstOrDefaultAsync(f => f.Email == email).ConfigureAwait(false);

                    if (user != null)
                        validationContext.AddFailure("Адрес электронной почты уже занят!");
                });

        }
    }
}