using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls.Selection;
using ReactiveUI;
using SalceteAppCafe.UI.Models;
using UninstallTools.Factory;

namespace SalceteAppCafe.UI.ViewModels
{
    public class AppManagerPageViewModel : ReactiveObject
    {
        private readonly ObservableCollection<InstalledAppsEntry> _data;
        public FlatTreeDataGridSource<InstalledAppsEntry> InstalledApps { get; }

        public string DisplayName { get; set; }
        public AppManagerPageViewModel()
        {
            DisplayName = "Test Mame";
            var installedAppsEntries =
                  ApplicationUninstallerFactory.GetUninstallerEntries()
                 .Select(x => new InstalledAppsEntry
                 {
                     AppName = x.DisplayNameTrimmed,
                     EstimatedSize = x.EstimatedSize.ToString(),
                     Publisher = x.PublisherTrimmed,
                     VersionNumber = x.DisplayVersion,
                     InstallDate = x.InstallDate,
                     InstallLocation = x.InstallLocation,
                     UninstallString = x.UninstallString,
                 });

            _data = new ObservableCollection<InstalledAppsEntry>(installedAppsEntries);

            InstalledApps = new FlatTreeDataGridSource<InstalledAppsEntry>(_data)
            {
                Columns =
                {
                    new TextColumn<InstalledAppsEntry,string>("Name", x => x.AppName),
                    new TextColumn<InstalledAppsEntry, string>("Name",
                    x => x.AppName,
                    new GridLength(6, GridUnitType.Star), new()
                    {
                        IsTextSearchEnabled = true,
                    }),
                    new TextColumn<InstalledAppsEntry, string>("Publisher", x => x.Publisher, new GridLength(3, GridUnitType.Star)),
                    new TextColumn<InstalledAppsEntry, string>("Version", x => x.VersionNumber, new GridLength(3, GridUnitType.Star)),
                    new TextColumn<InstalledAppsEntry, DateTime>("Install Date", x => x.InstallDate, new GridLength(3, GridUnitType.Star)),
                    new TextColumn<InstalledAppsEntry, string>("Install Location", x => x.InstallLocation, new GridLength(3, GridUnitType.Star)),
                    new TextColumn<InstalledAppsEntry, string>("Uninstall Command", x => x.UninstallString, new GridLength(3, GridUnitType.Star)),
                }

            };
            InstalledApps.RowSelection!.SingleSelect = true;
        }
    }
}
