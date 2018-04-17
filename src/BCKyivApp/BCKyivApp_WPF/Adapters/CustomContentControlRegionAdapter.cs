using BCKyivApp.WPF.Controls;
using BCKyivApp.WPF.Views;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BCKyivApp.WPF.Adapters
{
    public class CustomContentControlRegionAdapter : RegionAdapterBase<ContentControl>
    {
        public CustomContentControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, ContentControl regionTarget)
        {
            if (regionTarget.Content != null || (BindingOperations.GetBinding(regionTarget, System.Windows.Controls.ContentPresenter.ContentProperty) != null))
                throw new InvalidOperationException("No content");

            region.ActiveViews.CollectionChanged += delegate
            {
                regionTarget.Content = region.ActiveViews.FirstOrDefault();
            };
        }

        protected override IRegion CreateRegion()
        {
            var region = new SingleActiveRegion();
            var welcomeView = new MapView();
            region.Add(welcomeView);
            region.Activate(welcomeView);

            return region;
        }
    }
}