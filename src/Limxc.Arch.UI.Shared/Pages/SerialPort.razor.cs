using BootstrapBlazor.Components;
using Limxc.Arch.UI.Shared.Services;
using Limxc.Tools.Extensions;
using Limxc.Tools.Extensions.Communication;
using Limxc.Tools.SerialPort;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.NetworkInformation;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Limxc.Arch.UI.Shared.Pages
{
    public partial class SerialPort : IDisposable
    {
        [Inject]
        private DeviceSerialPortService Sp { get; set; }

        private SelectedItem[]? Ports;
        private SelectedItem[]? BaudRates { get; set; }
        private string? SelectedPort { get; set; }
        private int? SelectedBaudRate { get; set; }
        private bool CanConnect => string.IsNullOrWhiteSpace(SelectedPort);
        private bool SpIsConnected { get; set; }

        private string? Received { get; set; }
        private string? Send { get; set; }

        private CompositeDisposable _disposable = new CompositeDisposable();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Ports = Sp.GetPortNames().Select(p => new SelectedItem(p, p)).ToArray();
            BaudRates = new SerialPortSetting().AvailableBaudRates.Select(p => new SelectedItem(p.ToString(), p.ToString())).ToArray();

            Sp.ConnectionState.DistinctUntilChanged().Subscribe(p =>
                {
                    this.SpIsConnected = p;
                    InvokeAsync(() => StateHasChanged());
                }).DisposeWith(_disposable);

            Sp.Received.Subscribe(p =>
            {
                Received = $"@{DateTime.Now:HH:mm:ss}: " + p.ByteToHex().HexToAscII();
                InvokeAsync(() => StateHasChanged());
            }).DisposeWith(_disposable);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void BtnConn(MouseEventArgs e)
        {
            Sp.Start(new SerialPortSetting() { PortName = SelectedPort, BaudRate = SelectedBaudRate ?? 9600 });
        }

        private void BtnDisconn(MouseEventArgs e)
        {
            Sp.Stop();
        }

        private void BtnSend(MouseEventArgs e)
        {
            Sp.Send(Send.AscIIToHex().HexToByte());
        }
    }
}