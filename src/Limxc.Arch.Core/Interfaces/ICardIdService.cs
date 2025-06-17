using Limxc.Arch.Core.Shared.Interfaces;

namespace Limxc.Arch.Core.Services
{
    public interface ICardIdService : IDomainService
    {
        string GetCardId();
        bool Reset();
    }
}
