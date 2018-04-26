using BCKyivApp.WPF.Service.Interfaces;
using MahApps.Metro.Controls;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BCKyivApp.WPF.Service
{
    public class DialogService : IDialogService
    {
        private readonly IUnityContainer _container;

        public DialogService(IUnityContainer container)
        {
            _container = container;
        }

        public void ShowView<T>(object viewModel, MetroWindow parentWindow)
        {
            ShowView<T>(viewModel, parentWindow, true);
        }

        public void ShowView<T>(object viewModel, MetroWindow parentWindow, bool impactParentwindow)
        {
            var window = _container.Resolve<T>() as MetroWindow;

            if (window != null)
            {
                window.DataContext = viewModel;
                window.ShowInTaskbar = false;
                if (parentWindow != window)
                {
                    window.Owner = parentWindow;
                    if (impactParentwindow)
                    {
                        window.Closed += OnWindowClosed;
                    }
                    else
                    {
                        window.Closed += OnWindowClosedWithoutOverlay;
                    }

                    var ownerMetroWindow = (window.Owner as MetroWindow);

                    if (ownerMetroWindow != null)
                    {
                        if (!ownerMetroWindow.IsOverlayVisible())
                            ownerMetroWindow.ShowOverlayAsync();
                    }
                }

                window.Show();
            }
        }

        private void OnWindowClosedWithoutOverlay(object sender, EventArgs e)
        {
            var window = sender as MetroWindow;
            if (window != null)
            {
                window.Closed -= OnWindowClosed;
                var ownerWindow = window.Owner as MetroWindow;
                if (ownerWindow != null)
                {
                    ownerWindow.Focus();
                }
            }
        }

        public void ShowView<T>(object viewModel)
        {
            ShowView<T>(viewModel, Application.Current.MainWindow as MetroWindow);
        }


        private void OnWindowClosed(object sender, EventArgs e)
        {
            var window = sender as MetroWindow;
            if (window != null)
            {
                window.Closed -= OnWindowClosed;
                var ownerWindow = window.Owner as MetroWindow;
                if (ownerWindow != null)
                {
                    ownerWindow.HideOverlayAsync();
                    ownerWindow.Focus();
                }
            }
        }
    }
    }
