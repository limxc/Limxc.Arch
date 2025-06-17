using Limxc.Tools.Contract.Interfaces;
using Limxc.Tools.Extensions;

namespace Limxc.Arch.Core.Shared.Extensions
{
    public static class ConfigServiceExtension
    {
        public static bool _debug(this IConfigService configService, bool def = false)
        {
            try
            {
                return configService.Get("Debug").TryBool(def);
            }
            catch
            {
                return def;
            }
        }
    }
}
