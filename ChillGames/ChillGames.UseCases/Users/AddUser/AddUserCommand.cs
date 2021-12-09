namespace ChillGames.UseCases.Users.AddUser
{
    using System;
    using JetBrains.Annotations;
    using MediatR;

    /// <summary>
    /// Команда создания пользователя.
    /// </summary>
    [PublicAPI]
    public class AddUserCommand : IRequest<AddUserResponse>
    {
        /// <summary>
        /// Получает или задает имя пользователя.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Получает или задает адрес электронной почты пользователя.
        /// </summary>
        public string Email { get; set; }
    }
}