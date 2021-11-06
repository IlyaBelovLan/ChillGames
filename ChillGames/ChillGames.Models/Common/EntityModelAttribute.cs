namespace ChillGames.Models.Common
{
    using System;
    using JetBrains.Annotations;

    /// <summary>
    /// Атрибут модели сущности базы данных, для указания неявного использования.
    /// </summary>
    [MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
    [AttributeUsage(AttributeTargets.All)]
    public class EntityModelAttribute : Attribute
    {
    }
}