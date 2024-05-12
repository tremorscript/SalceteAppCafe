//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="SalceteAppCafe">
//     Author: Trelston Moraes
//     Copyright (c) SalceteAppCafe. All rights reserved.
//     License: GNU General Public License v3.0.
// </copyright>
//-----------------------------------------------------------------------

using Avalonia;

using Avalonia.ReactiveUI;
using System;

namespace SalceteAppCafe.UI.Desktop;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}
