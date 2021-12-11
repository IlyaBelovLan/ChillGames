namespace ChillGames.UseCases.Users.GetOrdersForUser
{
    using AutoMapper;
    using JetBrains.Annotations;
    using Models.Entities.Orders;
    using Models.Orders;

    /// <inheritdoc />
    [UsedImplicitly]
    public class GetOrdersForUserMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GetOrdersForUserMapping"/>.
        /// </summary>
        public GetOrdersForUserMapping()
        {
            CreateMap<EntityOrder, Order>();

            CreateMap<EntityOrderPosition, OrderPosition>()
                .ForMember(d => d.GameId, o => o.MapFrom(s => s.EntityGameId))
                .ForMember(d => d.OrderId, o => o.MapFrom(s => s.EntityOrderId));
        }
    }
}