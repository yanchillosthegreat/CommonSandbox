﻿using CommonSandbox.Services;
using CommonSandbox.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CommonSandbox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SidePanelService sidePanelService;

        public MainPage()
        {
            this.InitializeComponent();
            sidePanelService = SidePanelService.Instance;
            sidePanelService.ViewChanged += SidePanelService_ViewChanged;
            sidePanelService.SetView(SidePanelService.SidePanelViewType.Search);
        }

        private void SidePanelService_ViewChanged(object sender, SidePanelService.SidePanelViewChangedArgs e)
        {
            clientPanel.Content = e.View;
        }
    }
}
