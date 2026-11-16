using Eto.Drawing;
using Eto.Forms;
using NitroStudio2X.Forms;
using System;

namespace Nitro_Studio_2X_New
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var app = new Application(Eto.Platform.Detect);
            // Wpf doesn't follow the system light/dark theme unless asked to
            if (app.Platform.IsWpf)
                app.Theme = Themes.System;
            app.Run(new BaseEditor());
        }
    }
}
