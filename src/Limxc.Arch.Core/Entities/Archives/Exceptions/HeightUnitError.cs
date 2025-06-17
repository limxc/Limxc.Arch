using System;

namespace Limxc.Arch.Core.Archives.Exceptions
{
    public class HeightUnitError : Exception
    {
        public HeightUnitError(double value) : base($"身高单位错误(cm):{value}.")
        {
        }
    }
}