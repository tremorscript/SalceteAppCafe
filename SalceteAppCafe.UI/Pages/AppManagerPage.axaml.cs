//-----------------------------------------------------------------------
// <copyright file="AppManagerPage.axaml.cs" company="SalceteAppCafe">
//     Author: Trelston Moraes
//     Copyright (c) SalceteAppCafe. All rights reserved.
//     License: GNU General Public License v3.0.
// </copyright>
//-----------------------------------------------------------------------
using Avalonia.Controls;
using SalceteAppCafe.UI.ViewModels;

namespace SalceteAppCafe.UI.Pages
{
    public partial class AppManagerPage : UserControl
    {
        public AppManagerPage()
        {
            InitializeComponent();
            DataContext = new AppManagerPageViewModel();
        }
    }
}
