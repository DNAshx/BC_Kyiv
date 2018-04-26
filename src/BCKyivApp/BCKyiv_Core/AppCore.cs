using BCKyivApp.Core.Services;
using BCKyivApp.Core.Services.Interfaces;
using BCKyivApp.Data.Storages;
using BCKyivApp.Data.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace BCKyivApp.Core
{
    public class AppCore
    {
        IUnityContainer _container;

        public AppCore(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<ICentreStorage, CentreStorage>();
        }
    }
}
