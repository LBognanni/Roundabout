using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roundabout
{
    internal record Browser (string Name, string Command, string Icon)
    {
        public Image? GetImage()
        {
            var icon = ExtractIcon.FromExecutable(Icon);
            return icon?.ToBitmap();
        }
    }
}
