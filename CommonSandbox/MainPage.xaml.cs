using CommonSandbox.Models;
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
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new List<Сharacteristic>
            {
                new Сharacteristic {
                    Name = "Экран",
                    Params = new List<СharacteristicParam>
                    {
                        new СharacteristicParam { Name = "Диагональ", Value = "49''(124.5см)" },
                        new СharacteristicParam { Name = "Формат", Value = "16:9" },
                        new СharacteristicParam { Name = "Разрешение", Value = "3420x2160 Пикс(Ultra HD)" }
                    }
                },
                new Сharacteristic {
                    Name = "Поддержка 3D",
                    Params = new List<СharacteristicParam>
                    {
                        new СharacteristicParam { Name = "", Value = "пассивная технология" }
                    }
                }
            };
        }
    }
}
