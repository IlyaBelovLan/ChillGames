namespace ChillGames.UseCases.Common
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using JetBrains.Annotations;
    using MediatR.Pipeline;


    /// <inheritdoc />
    [UsedImplicitly]
    public class RequestValidator<TRequest> : IRequestPreProcessor<TRequest>
    {
        /// <summary>
        /// <see cref="AbstractValidator{TRequest}"/>.
        /// </summary>
        private readonly AbstractValidator<TRequest> _validator;

        /// <summary>
        /// Инициализирует экземпляр <see cref="RequestValidator{TRequest}"/>.
        /// </summary>
        /// <param name="validator"><see cref="AbstractValidator{TRequest}"/>.</param>
        public RequestValidator(AbstractValidator<TRequest> validator = null)
        {
            _validator = validator;
        }

        /// <inheritdoc />
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            if (_validator == null) return;

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            
            if (validationResult.Errors.Any())
                throw new ValidationException(validationResult.Errors);

        }
    }
}