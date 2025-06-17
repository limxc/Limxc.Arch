namespace Limxc.Arch.Core.Archives
{
    public class IdCard
    {
        public IdCard(string code)
        {
            //todo 校验身份证等
            Code = code.Trim();
        }

        public IdCard()
        {
        }

        public string Code { get; set; }
    }
}