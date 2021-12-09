namespace ChillGames.UseCases.Images.Common
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation;
    using JetBrains.Annotations;
    using Models.Images;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GameImageInfoListValidator : AbstractValidator<IEnumerable<GameImageInfo>>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameImageInfoValidator"/>.
        /// </summary>
        public GameImageInfoListValidator()
        {
            CascadeMode = CascadeMode.Stop;
            
            RuleFor(l => l)
                .NotEmpty()
                .WithMessage("Список изображений не может быть пуст");
            
            RuleForEach(l => l)
                .SetValidator(new GameImageInfoValidator());
            
            RuleFor(l => l.ToList())
                .Must(m => m.All(a => a.Order >= 1 && a.Order <= m.Count))
                .WithMessage(l => $"Порядковый номер изображения должен быть в пределах от 1 до {l.Count()}");

            RuleFor(l => l)
                .Must(m => m.Count(c => c.IsPreview == true) == 1)
                .WithMessage("Только одно изображение может быть обложкой!");
        }
    }
}