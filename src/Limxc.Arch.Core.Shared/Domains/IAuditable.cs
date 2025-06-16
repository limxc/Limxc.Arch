using System;

namespace Limxc.Arch.Core.Shared.Domains
{
    public interface IAuditable
    {
        DateTime Created { get; set; }
        DateTime? LastModified { get; set; }
    }
}