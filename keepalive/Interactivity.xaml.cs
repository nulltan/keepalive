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

namespace keepalive
{
    /// <summary>
    /// Interaction logic for Interactivity.xaml
    /// </summary>
    public partial class Interactivity : Window
    {
        public Interactivity()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // sideOffset definies by how many pixels are we moving the window to the left from right side of the display
            int sideOffset = 30;
            var height = new Binding("ActualHeight") { Source = MainWindow.ActualHeightProperty };
            var width = new Binding("ActualWidth") { Source = MainWindow.ActualWidthProperty };

            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;

            // sideOffset moves our window by pixels from the right
            this.Left = desktopWorkingArea.Right - this.Width - sideOffset;

            // without + 1 it leaves a 1px gap between the image and taskbar which is undesirable
            // also we are subtracting the image height so we get our interactivity window at top of the character
            this.Top = desktopWorkingArea.Bottom - this.Height + 1;
        }
    }
}
