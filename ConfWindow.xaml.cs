using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MazeGen
{
    /// <summary>
    /// Logique d'interaction pour ConfWindow.xaml
    /// </summary>
    public partial class ConfWindow : Window
    {
        public ConfWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;

            this.value.Content = (int)slider.Value;
            Global.Conf.CellSize = (int)slider.Value;
        }
    }
}
