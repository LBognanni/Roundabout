using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roundabout
{
    public interface IWindowsInterop
    {
        void StartProcess(string commandAndParameters);
    }
}
