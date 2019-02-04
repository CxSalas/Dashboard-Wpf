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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Variedades
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Hide and show sidebar menu
        private void ToggleMenu(object sender, RoutedEventArgs e)
        {
            if (Sidebar.Width == new GridLength(1, GridUnitType.Star))
            {
                Duration duration = new Duration(TimeSpan.FromMilliseconds(500));

                var animation = new GridLengthAnimation
                {
                    Duration = duration,
                    From = new GridLength(1, GridUnitType.Star),
                    To = new GridLength(0, GridUnitType.Star)
                };

                Sidebar.BeginAnimation(ColumnDefinition.WidthProperty, animation);
            }
            else
            {
                Duration duration = new Duration(TimeSpan.FromMilliseconds(500));

                var animation = new GridLengthAnimation
                {
                    Duration = duration,
                    From = new GridLength(0, GridUnitType.Star),
                    To = new GridLength(1, GridUnitType.Star)
                };

                Sidebar.BeginAnimation(ColumnDefinition.WidthProperty, animation);
            }
        }

        //Change content usercontrol from sidebar menu
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            ContentMain.Children.Clear();
            
            //Change usercontrol 
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemClients":
                    usc = new UserControlClient();
                    ContentMain.Children.Add(usc);
                    break;
                    
                default:
                    break;
            }
        }
    }
}
