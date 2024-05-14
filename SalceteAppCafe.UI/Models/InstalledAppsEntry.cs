//-----------------------------------------------------------------------
// <copyright file="InstalledAppsEntry.cs" company="SalceteAppCafe">
//     Author: Trelston Moraes
//     Copyright (c) SalceteAppCafe. All rights reserved.
//     License: GNU General Public License v3.0.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;

namespace SalceteAppCafe.UI.Models
{
    public class InstalledAppsEntry
    {
        public string AppName { get; set; } = String.Empty;

        public string Publisher { get; set; } = String.Empty;

        public string VersionNumber { get; set; } = String.Empty;

        public string EstimatedSize { get; set; } = String.Empty;

        public DateTime InstallDate { get; set; }

        public string InstallLocation { get; set; } = String.Empty;

        public string UninstallString { get; set; } = String.Empty;
    }
}
