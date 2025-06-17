using System;
using System.Collections.Generic;
using System.Text;
using Limxc.Arch.Core.Shared.Models;

namespace Limxc.Arch.Core.Shared.Interfaces
{
    public interface ILicenseService : IInfraService
    {
        LicenseCheckedResult Check();
    }
}
