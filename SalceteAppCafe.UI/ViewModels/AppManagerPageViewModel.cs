//-----------------------------------------------------------------------
// <copyright file="AppManagerPageViewModel.cs" company="SalceteAppCafe">
//     Author: Trelston Moraes
//     Copyright (c) SalceteAppCafe. All rights reserved.
//     License: GNU General Public License v3.0.
// </copyright>
//-----------------------------------------------------------------------
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls.Selection;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SalceteAppCafe.UI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using UninstallTools.Factory;

namespace SalceteAppCafe.UI.ViewModels
{
    public partial class AppManagerPageViewModel : ObservableObject
    {
        public Task<FlatTreeDataGridSource<InstalledAppsEntry>> InstalledApps => PopulateInstalledApplicationsAsync();

        public FlatTreeDataGridSource<InstalledAppsEntry> Source { get; set; }

        [ObservableProperty]
        public int currentStepValue;

        [ObservableProperty]
        public string? currentStepMessage;

        [ObservableProperty]
        public int totalStepCount;

        [ObservableProperty]
        public bool isReporterVisible = true;
        public AppManagerPageViewModel()
        {
            Source = new FlatTreeDataGridSource<InstalledAppsEntry>(new List<InstalledAppsEntry>());
            currentStepMessage = "Fetching the list of installed applications.";
            totalStepCount = 8;
        }

        partial void OnCurrentStepValueChanged(int oldValue, int newValue)
        {
            if (newValue == TotalStepCount) {
                IsReporterVisible = false; 
            }
        }

        [RelayCommand]
        private async Task Refresh()
        {
            await this.InstalledApps;
        }

        public async Task<FlatTreeDataGridSource<InstalledAppsEntry>> PopulateInstalledApplicationsAsync()
        {
            CurrentStepValue = 1;
            IsReporterVisible = true;
            IProgress<int> progressReporter = new Progress<int>(val => CurrentStepValue = val);

            var installedAppsEntries = await Task.Run(() => ApplicationUninstallerFactory.GetUninstallerEntries(progressReporter));

            var install = installedAppsEntries.Select(x => new InstalledAppsEntry
            {
                AppName = x.DisplayNameTrimmed,
                EstimatedSize = x.EstimatedSize.ToString(),
                Publisher = x.PublisherTrimmed,
                VersionNumber = x.DisplayVersion,
                InstallDate = x.InstallDate,
                InstallLocation = x.InstallLocation,
                UninstallString = x.UninstallString,
            });

            var grid = new FlatTreeDataGridSource<InstalledAppsEntry>(
                               new ObservableCollection<InstalledAppsEntry>(install))
            {
                Columns =
                {
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

            grid.RowSelection!.SingleSelect = true;
            this.Source = grid;
            return grid;
        }

        [RelayCommand]
        private void UninstallApplication()
        {
            var selection = ((ITreeSelectionModel)Source!.Selection!).SelectedItem as InstalledAppsEntry;
        }
    }
}
