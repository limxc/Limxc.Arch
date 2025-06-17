using Android.App;
using Android.Runtime;
using Limxc.Arch.UI.MAUIBlazor;

namespace Limxc.Arch.UI
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership) { }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
