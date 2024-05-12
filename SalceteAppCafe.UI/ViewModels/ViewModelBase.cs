//-----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="SalceteAppCafe">
//     Author: Trelston Moraes
//     Copyright (c) SalceteAppCafe. All rights reserved.
//     License: GNU General Public License v3.0.
// </copyright>
//-----------------------------------------------------------------------
using ReactiveUI;

namespace SalceteAppCafe.UI.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public int Test { get; set; }
}
