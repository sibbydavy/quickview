using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace QuickAccess.BuildingBlocks
{
    /// <summary>
    /// Interaction logic for ucBlock.xaml
    /// </summary>
    public partial class ucBlock : UserControl
    {
        String imagePath = System.AppDomain.CurrentDomain.BaseDirectory + @"Images\";
         
        public event EventHandler OnAfterExecuteCommand;

        public ICommand ClickOnBlock
        {
            get { return (ICommand)GetValue(ClickBlockCommandProperty); }
            set { SetValue(ClickBlockCommandProperty, value); }
        }

        public static readonly DependencyProperty ClickBlockCommandProperty =
            DependencyProperty.Register("ClickOnBlock", typeof(ICommand), typeof(ucBlock), 
                new UIPropertyMetadata(null));


        public String ActionItemImageFullPath
        {
            get { return ""; }
            set
            {
                BitmapImage biBackup = new BitmapImage();
                biBackup.BeginInit();
                biBackup.UriSource = new Uri(imagePath + value);
                biBackup.EndInit();
                Image imgMyProjects = (Image)btnActionItem.Template.FindName("imgActionItem", btnActionItem);
                imgMyProjects.Source = biBackup;
            }
        }

        public ucBlock()
        {
            InitializeComponent();
        }

        private void OnLoadMe(object sender, RoutedEventArgs e)
        {

        }

        private void btnActionItem_Click(object sender, RoutedEventArgs e)
        {
            OnAfterExecuteCommand?.Invoke(sender, e);
        }
    }
}
