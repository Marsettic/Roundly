using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Winforms = System.Windows.Forms;

namespace Roundly
{
    /// <summary>
    /// Interaction logic for RoundlyOverlay.xaml
    /// </summary>
    public partial class RoundlyOverlay : Window
    {
        int RoundCorner = 0;
        private Winforms.NotifyIcon TrayIcon = new Winforms.NotifyIcon();
        SettingsSystem Settings = new SettingsSystem();

        public RoundlyOverlay()
        {

            if (Settings.ReadSettings("NotFirstTime") != "true")
            {
                Settings.SaveSettings("NotFirstTime", "true");
                Settings.SaveSettings("RoundCornerShape", "true");
                Settings.SaveSettings("RoundCornerAMT", "10");
            }
            Int32.TryParse(Settings.ReadSettings("RoundCornerAMT"), out RoundCorner);

            this.TrayIcon.MouseDown += new Winforms.MouseEventHandler(TrayIcon_MouseDown);
            this.TrayIcon.Icon = Roundly.Properties.Resources.RoundlyLogo1;
            this.TrayIcon.Visible = true;
            InitializeComponent();

        }

        void TrayIcon_MouseDown(object sender, Winforms.MouseEventArgs e)
        {
            if (e.Button == Winforms.MouseButtons.Left)
            {
                ContextMenu CMenu = (ContextMenu)this.FindResource("TrayIconContextMenu");
                CMenu.IsOpen = true;
            }
        }

        void SetCornerSize(int RoundSize)
        {
            LTCorner.Width = RoundSize;
            LTCorner.Height = RoundSize;

            RTCorner.Width = RoundSize;
            RTCorner.Height = RoundSize;

            LBCorner.Width = RoundSize;
            LBCorner.Height = RoundSize;

            RBCorner.Width = RoundSize;
            RBCorner.Height = RoundSize;

            ELTCorner.Width = RoundSize;
            ELTCorner.Height = RoundSize;

            ERTCorner.Width = RoundSize;
            ERTCorner.Height = RoundSize;

            ELBCorner.Width = RoundSize;
            ELBCorner.Height = RoundSize;

            ERBCorner.Width = RoundSize;
            ERBCorner.Height = RoundSize;
        }

        private void RoundlyOverlay_Loaded(object sender, RoutedEventArgs e)
        {
            Point location = this.PointToScreen(new Point(0, 0));
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;

            if (Settings.ReadSettings("RoundCornerShape") == "true")
                RoundCornerGrid.Visibility = Visibility.Visible;
            else
                EdgeCornerGrid.Visibility = Visibility.Visible;

            SetCornerSize(RoundCorner);
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            Topmost = true;
            this.Activate();
            this.Focus();
        }

        private void RefreshCorner_Click(object sender, RoutedEventArgs e)
        {
            this.TrayIcon.Visible = false;
            new RoundlyOverlay().Show();
            this.Close();
        }

        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            new RoundlySettings().ShowDialog();
        }
    }
}
