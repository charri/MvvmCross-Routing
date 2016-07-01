using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace Charri.MvvmCross.Plugins.Routing.Plugin
{
    public sealed class PluginLoader
        : IMvxConfigurablePlugin
    {
        private MvxRoutingConfiguration _configuration = new MvxDefaultRoutingConfiguration();

        public void Load()
        {
            MvxRoutingService.LoadRoutes(_configuration.SourceAssemblies);
            Mvx.LazyConstructAndRegisterSingleton(typeof(IMvxRoutingService), Mvx.IocConstruct<MvxRoutingService>);
        }

        public void Configure(IMvxPluginConfiguration configuration)
        {
            if (!(configuration is MvxRoutingConfiguration))
                return;

            _configuration = (MvxRoutingConfiguration) configuration;
        }
    }
}
