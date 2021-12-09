namespace ChillGames.UseCases.Users.GetUserInfo
{
    using AutoMapper;
    using JetBrains.Annotations;
    using Models.Entities.Users;
    using Models.Users;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetUserInfoMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetUserInfoMapping"/>.
        /// </summary>
        public GetUserInfoMapping()
        {
            CreateMap<EntityUser, UserInfo>();
        }
    }
}