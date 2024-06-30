﻿using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace MovieManager.TrayApp
{
    /// <summary>
    /// Provides bindable properties and commands for the NotifyIcon. In this sample, the
    /// view model is assigned to the NotifyIcon in XAML. Alternatively, the startup routing
    /// in App.xaml.cs could have created this view model, and assigned it to the NotifyIcon.
    /// </summary>
    public class NotifyIconViewModel
    {
        public ICommand OpenBrowserCommand
        {
            get
            {
                // May need change port when running on new machine
                var webAppHost = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["WebAppHost"];
                return new DelegateCommand { CommandAction = () => Process.Start("explorer.exe", webAppHost) };
            }
        }

        public ICommand ExitApplicationCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CommandAction = () =>
                    {
                        Application.Current.Shutdown();
                    }
                };
            }
        }
    }
}