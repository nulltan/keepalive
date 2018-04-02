using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
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

namespace keepalive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // sideOffset definies by how many pixels are we moving the window to the left from right side of the display
            int sideOffset = 30;

            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;

            // sideOffset moves our window by pixels from the right
            this.Left = desktopWorkingArea.Right - this.Width - sideOffset;

            // without + 1 it leaves a 1px gap between the image and taskbar which is undesirable
            this.Top = desktopWorkingArea.Bottom - this.Height + 1; 
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            // Our image location needs to be dynamic to support themes!
            string currentTheme = "emi"; // Grab that from config, current implementation is for debugging only!

            // Creating a new BitmapImage
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.CacheOption = BitmapCacheOption.None;
            b.UriCachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
            b.CacheOption = BitmapCacheOption.OnLoad;
            b.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            b.UriSource = new Uri(@"theme/" + currentTheme + "/idle1.png", UriKind.Relative);
            b.EndInit();

            // Get Image reference from sender.
            var image = sender as Image;
            // Assign Source.
            image.Source = b;

            // We need to refresh our window location so we invoke an event that contains window placement code
            Dispatcher.BeginInvoke(new EventHandler<RoutedEventArgs>(Window_Loaded), this, new RoutedEventArgs());
        }

        public double ImageHeight()
        {
            return charaImage.Height;
        }
    }
}
