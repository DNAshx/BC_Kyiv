using BCKyivApp.Core.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace BCKyivApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //log4net.Config.XmlConfigurator.Configure();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
            var viewName = viewType.Name;
            var viewModelAssemblyName = typeof(NavigationViewModel).Assembly.FullName;
            var viewModelName = String.Format(CultureInfo.InvariantCulture, "BCKyivApp.Core.ViewModels.{0}Model, {1}", viewName, viewModelAssemblyName);
            return Type.GetType(viewModelName);
        });

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}

