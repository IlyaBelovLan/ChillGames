namespace ChillGames.WebApi.Infrastructure
{
    using System;
    using System.Linq;
    using Data.StoreContext;
    using FluentValidation;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using UseCases.Common.Exceptions;

    /// <inheritdoc />
    [UsedImplicitly]
    public class ExceptionHandler : IExceptionFilter
    {
        /// TODO: убрать exception.message.
        /// <inheritdoc />
        public void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;
            
            if(exception == null)
                return;
            
            context.Result =  exception switch
            {
                ValidationException validationException => BadRequestResult(validationException.Errors.Select(s => s.ErrorMessage)),
                StoreDbContextException storeDbContextException => NotFoundRequestResult(storeDbContextException.Message),
                UseCaseException useCaseException => NoContentRequestResult(useCaseException.Message),
                _ => UnknownErrorRequestResult("Неизвестная ошибка: " + exception.Message)
            };
        }
        
        /// <summary>
        /// Создает результат отсутствия контента.
        /// </summary>
        /// <param name="value">Информация об отсутствующем контенте.</param>
        /// <returns>Экземпляр <see cref="JsonResult"/>.</returns>
        private static JsonResult NoContentRequestResult(object value) => JsonRequestResult(new NoContentResult(value), (int)HttpCodes.NotFound);
        
        /// <summary>
        /// Создает результат ошибки поиска.
        /// </summary>
        /// <param name="value">Информация по ошибке поиска.</param>
        /// <returns>Экземпляр <see cref="JsonResult"/>.</returns>
        private static JsonResult NotFoundRequestResult(object value) => JsonRequestResult(new NotFoundResult(value), (int)HttpCodes.NotFound);
        
        /// <summary>
        /// Создает результат неизвестной ошибки.
        /// </summary>
        /// <param name="value">Информация по неизвестной ошибке..</param>
        /// <returns>Экземпляр <see cref="JsonResult"/>.</returns>
        private static JsonResult UnknownErrorRequestResult(object value) => JsonRequestResult(new UnknownErrorResult(value), (int)HttpCodes.UnknownError);

        /// <summary>
        /// Создает результат плохого запроса.
        /// </summary>
        /// <param name="value">Информация по плохому запросу.</param>
        /// <returns>Экземпляр <see cref="JsonResult"/>.</returns>
        private static JsonResult BadRequestResult(object value) => JsonRequestResult(new BadRequestResult(value), (int)HttpCodes.BadRequest);
        
        /// <summary>
        /// Возвращает экземпляр <see cref="JsonResult"/>.
        /// </summary>
        /// <param name="value">Объект-результат.</param>
        /// <param name="statusCode">Код статуса выполнения запроса.</param>
        /// <returns>Экземпляр <see cref="JsonResult"/>.</returns>
        private static JsonResult JsonRequestResult(object value, int statusCode) => new JsonResult(value) { StatusCode = statusCode };
    }
}