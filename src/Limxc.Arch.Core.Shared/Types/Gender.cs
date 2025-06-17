using System.ComponentModel;

namespace Limxc.Arch.Core.Shared.Types
{
    public enum Gender
    {
        [Description("未知")]
        Unknown,

        [Description("男")]
        Male,

        [Description("女")]
        Female,

        [Description("中性")]
        Neutral,
    }
}
