namespace ChillGames.Models.Common.Extensions
{
    using System;
    using System.Linq.Expressions;
    using Entities.Games;
    using Games;

    /// <summary>
    /// Методы расширений для <see cref="OrderedField"/>.
    /// </summary>
    public static class OrderedFieldExtensions
    {
        public static Expression<Func<EntityGame, dynamic>> ToSortExpression(this OrderedField orderedField)
        {
            return orderedField switch
            {
                OrderedField.Price => game => game.Price,
                OrderedField.ReleaseDate => game => game.ReleaseDate,
                _ => throw new ArgumentOutOfRangeException(nameof(orderedField))
            };
        }
    }
}