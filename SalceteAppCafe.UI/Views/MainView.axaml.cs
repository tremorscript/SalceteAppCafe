//-----------------------------------------------------------------------
// <copyright file="MainView.axaml.cs" company="SalceteAppCafe">
//     Author: Trelston Moraes
//     Copyright (c) SalceteAppCafe. All rights reserved.
//     License: GNU General Public License v3.0.
// </copyright>
//-----------------------------------------------------------------------
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SalceteAppCafe.UI.Pages;

namespace SalceteAppCafe.UI.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        //InitializeComponent();
        AvaloniaXamlLoader.Load(this);

    }
}
