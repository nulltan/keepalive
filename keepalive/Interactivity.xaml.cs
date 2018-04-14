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
            // let's get MainWindow width and height, shall we?
            Window mainWindow = Application.Current.MainWindow;

            // sideOffset definies by how many pixels are we moving the window to the left from right side of the display
            int sideOffset = 80;
            int vertOffset = 40;

            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;

            // sideOffset moves our window by pixels from the right
            this.Left = desktopWorkingArea.Right - mainWindow.ActualWidth - sideOffset;
            //this.Left = 800;

            // without + 1 it leaves a 1px gap between the image and taskbar which is undesirable
            // also we are subtracting the image height so we get our interactivity window at top of the character
            // vertOffset moves our window by pixels from the bottom, get it negative to get it lower than window!
            this.Top = desktopWorkingArea.Bottom - mainWindow.ActualHeight + 1 - vertOffset;
            //this.Top = 800;

            // Inactivity tip text
            txtAction.Foreground = Brushes.Gray;
            txtAction.Text = "What do you want to do?";
            txtAction.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(txtAction_GotKeyboardFocus);
            txtAction.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(txtAction_LostKeyboardFocus);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                (sender as TextBox).Text = string.Empty;
            }
        }

        // https://stackoverflow.com/questions/7425618/how-can-i-add-a-hint-text-to-wpf-textbox xD
        private void txtAction_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                //If nothing has been entered yet.
                if (((TextBox)sender).Foreground == Brushes.Gray)
                {
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).Foreground = Brushes.Black;
                }
            }
        }


        private void txtAction_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //Make sure sender is the correct Control.
            if (sender is TextBox)
            {
                //If nothing was entered, reset default text.
                if (((TextBox)sender).Text.Trim().Equals(""))
                {
                    ((TextBox)sender).Foreground = Brushes.Gray;
                    ((TextBox)sender).Text = "What do you want to do?";
                }
            }
        }
    }
}
