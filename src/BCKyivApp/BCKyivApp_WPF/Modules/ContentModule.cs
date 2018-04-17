using BCKyivApp.Core.ViewModels;
using BCKyivApp.Core.ViewModels.Interfaces;
using BCKyivApp.WPF.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCKyivApp.WPF.Modules
{
    public class ContentModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public ContentModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(MapView));

            _container.RegisterTypeForNavigation<MapView>();
            _container.RegisterTypeForNavigation<NavigationView>();

            _container.RegisterType<INavigationViewModel, NavigationViewModel>();
            _container.RegisterType<IMapViewModel, MapViewModel>();
        }
    }
}