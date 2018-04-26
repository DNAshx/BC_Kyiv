using BCKyivApp.Core.Models;
using BCKyivApp.WPF.Resources;
using Microsoft.Practices.Unity;
using Prism.Regions;
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

namespace BCKyivApp.WPF.Views
{
    /// <summary>
    /// Interaction logic for NavigationView.xaml
    /// </summary>
    public partial class NavigationView : UserControl
    {
        public NavigationView()
        {
            InitializeComponent();            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rm = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IRegionManager>();
            
            if (rm != null)
            {
                var navItem = (NavigationLinkModel)((ListView)e.Source).SelectedItem;
                rm.RequestNavigate(Strings.ContentRegion, navItem.ViewName);
            }
        }
    }
}
