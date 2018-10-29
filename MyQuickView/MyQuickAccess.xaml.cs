using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace QuickAccess
{
    /// <summary>
    /// Interaction logic for MyQuickAccess.xaml
    /// </summary>
    public partial class MyQuickAccess : Window
    {
        String imagePath = System.AppDomain.CurrentDomain.BaseDirectory + @"Images\";
        Boolean flagViewOpen = false;


        public MyQuickAccess()
        {
            InitializeComponent();
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ucRight.ActionItemImageFullPath = "MyBackup.ico";
            ucDown.ActionItemImageFullPath = "notepad.ico";
            ucUp.ActionItemImageFullPath = "vs.ico";
            ucLeft.ActionItemImageFullPath = "RoboClient.ico";

            ucRight.OnAfterExecuteCommand += TrackerActionItem_OnAfterExecuteCommand;
            ucDown.OnAfterExecuteCommand += TrackerActionItem_OnAfterExecuteCommand;
            ucUp.OnAfterExecuteCommand += TrackerActionItem_OnAfterExecuteCommand;
            ucLeft.OnAfterExecuteCommand += TrackerActionItem_OnAfterExecuteCommand;

            TrackerDefaultStyle();
            TrackerDefaultPosition();

        }

        private void TrackerActionItem_OnAfterExecuteCommand(object sender, EventArgs e)
        {
            TrackerDefaultStyle();
            TrackerDefaultPosition();
        }


        void TrackerDefaultPosition()
        {
            grdTrackers.Visibility = Visibility.Collapsed;
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - (this.Width + 1);
            this.Top = desktopWorkingArea.Bottom - (this.Height + 20);
        }

        void TrackerDefaultStyle()
        {

            flagViewOpen = false;
            this.Height = 37;
            this.Width = 40;
            brdOuterArea.Opacity = 0.65;
            grdTrackers.Visibility = Visibility.Collapsed;

            LinearGradientBrush gradient = new LinearGradientBrush();
            gradient.GradientStops.Add(new GradientStop(Colors.Black, -25));
            gradient.GradientStops.Add(new GradientStop(Color.FromArgb(100, 69, 87, 186), -10));
            brdOuterArea.Background = gradient;
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!flagViewOpen)
                {
                    flagViewOpen = true;
                    this.Height = 100;
                    this.Width = 100;

                    brdOuterArea.Opacity = 2;

                    var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
                    this.Left = desktopWorkingArea.Right - (this.Width + 50);
                    this.Top = desktopWorkingArea.Bottom - (this.Height + 50);

                    grdTrackers.Visibility = Visibility.Visible;

                    LinearGradientBrush gradient = new LinearGradientBrush();
                    gradient.GradientStops.Add(new GradientStop(Colors.Black, -5));
                    gradient.GradientStops.Add(new GradientStop(Color.FromArgb(100, 208, 218, 225), -1));
                    brdOuterArea.Background = gradient;

                }

            }
        }
    }
}
