using System;

namespace Limxc.Arch.Core.Archives.Exceptions
{
    public class BirthDateError : Exception
    {
        public BirthDateError() : base("出生日期错误.")
        {
        }
    }
}