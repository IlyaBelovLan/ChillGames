namespace ChillGames.UseCases.Images.AddGameImages
{
    using System.Linq;
    using FluentValidation;
    using JetBrains.Annotations;
    using Models.Common.Extensions;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddGameImagesCommandValidator : AbstractValidator<AddGameImagesCommand>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AddGameImagesCommandValidator"/>.
        /// </summary>
        public AddGameImagesCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(c => c.Images)
                .NotEmpty()
                .WithMessage("Список изображений не может быть пуст");
            
            RuleForEach(c => c.Images)
                .Must(m => !m.ImageCode.IsNullOrEmpty())
                .WithMessage("Код изображения не может быть пустым!");

            RuleFor(c => c)
                .Must(m => m.Images.All(a => a.Order >= 1 && a.Order <= m.Images.Count))
                .WithMessage(с => $"Порядковый номер изображения должен быть в пределах от 1 до {с.Images.Count}");
        }
        
    }
}