using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Roundabout.frmApp;

namespace Roundabout
{
    public class frmAppViewModel : ReactiveObject, IButtonCommandReceiver
    {
        private readonly ISettings _settings;
        private readonly IWindowsInterop _windowsInterop;
        private readonly ObservableCollection<Browser> _browsers;
        private string _url;
        private string _openingApp;

        public frmAppViewModel(string url, string openingApp, IBrowsersFinder finder, ISettings settings, IWindowsInterop windowsInterop)
        {
            _settings = settings;
            _windowsInterop = windowsInterop;
            _browsers = new ObservableCollection<Browser>(finder.FindBrowsers());
            _url = url;
            _openingApp = openingApp;
        }

        public string Url
        {
            get => _url;
            set => this.RaiseAndSetIfChanged(ref _url, value);
        }

        public string OpeningApp
        {
            get => _openingApp;
            set => this.RaiseAndSetIfChanged(ref _openingApp, value);
        }

        public ObservableCollection<Browser> Browsers => _browsers;

        public void OpenBrowserCommand(string exePath)
        {
            var command = exePath.Replace("%1", Url);
            _windowsInterop.StartProcess(command);
        }
    }
}
