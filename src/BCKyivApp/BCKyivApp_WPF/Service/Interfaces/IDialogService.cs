using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCKyivApp.WPF.Service.Interfaces
{
    public interface IDialogService
    {
        void ShowView<T>(object viewModel);

        void ShowView<T>(object viewModel, MetroWindow parentWindow);

        void ShowView<T>(object viewModel, MetroWindow parentWindow, bool impactParentwindow);
    }
}
