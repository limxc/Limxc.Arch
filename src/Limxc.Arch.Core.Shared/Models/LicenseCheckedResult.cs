namespace Limxc.Arch.Core.Shared.Models
{
    public class LicenseCheckedResult
    {
        public LicenseCheckedResult(bool available, string message = null)
        {
            Available = available;
            Message = message;
        }

        public bool Available { get; set; }
        public string Message { get; set; }
    }
}
