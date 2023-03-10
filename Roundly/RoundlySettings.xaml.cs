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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Roundly
{
    /// <summary>
    /// Interaction logic for RoundlySettings.xaml
    /// </summary>
    public partial class RoundlySettings
    {

        SettingsSystem Settings = new SettingsSystem();

        public RoundlySettings()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void CornerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CornerSlider != null)
                CornerSliderText.Content = "Corner Size : " + CornerSlider.Value;
        }

        private void SaveCornerSizeButton_Click(object sender, RoutedEventArgs e) => Settings.SaveSettings("RoundCornerAMT", CornerSlider.Value.ToString());
    }
}
