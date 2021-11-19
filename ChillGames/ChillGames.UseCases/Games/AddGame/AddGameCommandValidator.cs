namespace ChillGames.UseCases.Games.AddGame
{
    using Data.Repositories.TagsRepository;
    using FluentValidation;
    using JetBrains.Annotations;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddGameCommandValidator : AbstractValidator<AddGameCommand>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AddGameCommandValidator"/>.
        /// </summary>
        public AddGameCommandValidator(ITagsRepository tagsRepository)
        {
            CascadeMode = CascadeMode.Stop;

            RuleForEach(c => c.Tags)
                .NotEmpty()
                .WithMessage("Тег не может быть пустым!");
            
            RuleFor(c => c.Title)
                .NotEmpty()
                .WithMessage("Не задано название игры");

            RuleFor(c => c.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Цена не может быть меньше нуля!");
            
            RuleFor(c => c.Discount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Скидка не может быть меньше нуля!");

            RuleFor(c => c.Launchers)
                .NotEmpty()
                .WithMessage("Не заданы лаунчеры игры!");

            RuleFor(c => c.Platforms)
                .NotEmpty()
                .WithMessage("Не заданы платформы для игры!");

            RuleFor(c => c.Count)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Количество игр не может быть меньше нуля!");
        }
    }
}