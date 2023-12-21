using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roundabout
{
    public class UrlButton : Button, IViewFor<UrlButtonViewModel>
    {
        public UrlButtonViewModel? ViewModel { get; set; }
        object? IViewFor.ViewModel { get => ViewModel; set => ViewModel = value as UrlButtonViewModel; }
    }

    public class UrlButtonViewModel : ReactiveObject
    {
        //public UrlButtonViewModel
    }

    public interface IButtonCommandReceiver
    {
        void OpenBrowserCommand(string exePath);
    }

    internal class BrowserListConverter : IBindingTypeConverter
    {
        private readonly IButtonCommandReceiver _receiver;

        public BrowserListConverter(IButtonCommandReceiver receiver)
        {
            _receiver = receiver;
        }

        public int GetAffinityForObjects(Type fromType, Type toType)
        {
            if (toType != typeof(Control.ControlCollection))
            {
                return 0;
            }

            if (fromType.GetInterface("IEnumerable") == null)
            {
                return 0;
            }

            return 10;
        }

        public bool TryConvert(object @from, Type toType, object conversionHint, out object? result)
        {
            var enumerable = (IEnumerable)from;

            if (enumerable == null)
            {
                result = null;
                return false;
            }

            var viewModelControlHosts = new List<Button>();
            foreach (var browser in enumerable.OfType<Browser>())
            {
                var button = new Button();
                button.Text = AddNewlines(browser.Name);
                button.Image = browser.GetImage();
                button.Size = new Size(120, 120);
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.TextAlign = ContentAlignment.BottomCenter;
                button.AutoSizeMode = AutoSizeMode.GrowOnly;
                button.AutoSize = true;
                button.Tag = browser.Command;
                button.FlatStyle = FlatStyle.Flat;
                button.Cursor = Cursors.Hand;
                button.Click += Button_Click;

                viewModelControlHosts.Add(button);
            }

            result = viewModelControlHosts;
            return true;
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            var button = sender as Button;
            var command = button?.Tag?.ToString();
            if (!string.IsNullOrEmpty(command))
            {
                _receiver.OpenBrowserCommand(command);
            }
        }

        private string AddNewlines(string name)
        {
            if (name.Count(x => x == ' ') > 1)
            {
                var index = name.IndexOf(' ');
                index = name.IndexOf(' ', index + 1);
                return name.Substring(0, index) + "\r\n" + name.Substring(index + 1);
            }

            return name;
        }
    }
}
