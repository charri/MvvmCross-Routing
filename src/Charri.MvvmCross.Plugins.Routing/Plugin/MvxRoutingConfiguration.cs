using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace Charri.MvvmCross.Plugins.Routing.Plugin
{
    public class MvxRoutingConfiguration
        : IMvxPluginConfiguration
    {

        public virtual Assembly[] SourceAssemblies { get; set; }

    }


    public class MvxDefaultRoutingConfiguration
        : MvxRoutingConfiguration
    {
        public override Assembly[] SourceAssemblies
        {
            get
            {
                // this is default implementaiton for MvxSetup.GetViewModelAssemblies
                // https://github.com/MvvmCross/MvvmCross/blob/4.0/MvvmCross/Core/Core/Platform/MvxSetup.cs#L272
                var app = Mvx.Resolve<IMvxApplication>();
                var assembly = app.GetType().GetTypeInfo().Assembly;
                return new[] { assembly };
            }
        }
    }
}
