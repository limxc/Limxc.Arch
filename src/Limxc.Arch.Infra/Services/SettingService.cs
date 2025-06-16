using Limxc.Tools.Contract.Interfaces;
using Limxc.Tools.Core.Services;

namespace Limxc.Arch.Infra.Services
{
    public class SettingService<T> : JsonFileSettingService<T>, ISettingService<T> where T : class, new()
    {
        private string _folder;

        public SettingService(string folder)
        {
            _folder = folder;
        }

        protected override string Folder => _folder;
    }
}