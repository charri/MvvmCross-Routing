using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charri.MvvmCross.Plugins.Routing.Plugin;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Plugins;
using RoutingExample.Core.ViewModels;

namespace RoutingExample.Core
{
    public class App : MvxApplication
    {

        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<MainViewModel>();
        }

        //public override void LoadPlugins(IMvxPluginManager pluginManager)
        //{
        //    base.LoadPlugins(pluginManager);

        //    pluginManager.EnsurePluginLoaded<PluginLoader>();
        //}
    }
}
