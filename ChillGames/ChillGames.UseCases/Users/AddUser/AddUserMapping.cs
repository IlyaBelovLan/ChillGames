namespace ChillGames.UseCases.Users.AddUser
{
    using System;
    using AutoMapper;
    using JetBrains.Annotations;
    using Models.Entities.Users;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddUserMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AddUserMapping"/>.
        /// </summary>
        public AddUserMapping()
        {
            CreateMap<AddUserCommand, EntityUser>()
                .ForMember(d => d.RegistrationDate, o => o.MapFrom(s => DateTime.Now));
        }
    }
}