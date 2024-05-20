//-----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="SalceteAppCafe">
//     Author: Trelston Moraes
//     Copyright (c) SalceteAppCafe. All rights reserved.
//     License: GNU General Public License v3.0.
// </copyright>
//-----------------------------------------------------------------------

using CommunityToolkit.Mvvm.ComponentModel;

namespace SalceteAppCafe.UI.ViewModels;

public class ViewModelBase : ObservableObject
{
    public int Test { get; set; }
}
