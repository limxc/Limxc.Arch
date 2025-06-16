using System;

namespace Limxc.Arch.Core.Shared.Domains
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }

    public interface IEntity : IEntity<Guid>
    {
    }
}