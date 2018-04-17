using BCKyivApp.Core.ViewModels.Interfaces;
using BCKyivApp.WPF.Adapters;
using BCKyivApp.WPF.Controls;
using BCKyivApp.WPF.Modules;
using BCKyivApp.WPF.Views;
using Microsoft.Practices.ServiceLocation;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BCKyivApp.WPF
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow?.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ContentModule));
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var behavior = ServiceLocator.Current.GetInstance<IRegionBehaviorFactory>();
            var mappings = base.ConfigureRegionAdapterMappings();

            mappings.RegisterMapping(typeof(ContentControl), new CustomContentControlRegionAdapter(behavior));

            return mappings;
        }
    }
}
