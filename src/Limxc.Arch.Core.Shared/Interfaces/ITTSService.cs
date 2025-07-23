using System.Threading.Tasks;

namespace Limxc.Arch.Core.Shared.Interfaces
{
    public interface ITTSService
    {
        Task Speak(string text = "你好，欢迎使用 Blazor MAUI！");
    }
}
