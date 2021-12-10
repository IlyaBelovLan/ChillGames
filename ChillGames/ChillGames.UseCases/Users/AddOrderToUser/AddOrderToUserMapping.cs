namespace ChillGames.UseCases.Users.AddOrderToUser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using JetBrains.Annotations;
    using Models.Entities.Orders;
    using Models.Orders;

    /// <inheritdoc />
    [UsedImplicitly]
    public class AddOrderToUserMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AddOrderToUserMapping"/>.
        /// </summary>
        public AddOrderToUserMapping()
        {
            CreateMap<OrderPositionInfo, EntityOrderPosition>()
                .ForMember(d => d.EntityGameId, o => o.MapFrom(s => s.GameId))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.EntityGame.Price * (100 - s.EntityGame.Discount) / 100 * s.Count))
                .ForMember(d => d.Count, o => o.MapFrom(s => s.Count));

            CreateMap<IList<EntityOrderPosition>, EntityOrder>()
                .ForMember(d => d.OrderDate, o => o.MapFrom(s => DateTime.Now))
                .ForMember(d => d.OrderPositions, o => o.MapFrom(s => s))
                .ForMember(d => d.Amount, o => o.MapFrom(s => s.Select(sl => sl.Price).Sum()));
        }
    }
}