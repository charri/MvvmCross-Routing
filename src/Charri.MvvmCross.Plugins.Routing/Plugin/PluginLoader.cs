using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace Charri.MvvmCross.Plugins.Routing.Plugin
{
    public sealed class PluginLoader
        : IMvxConfigurablePluginLoader
    {

        public static readonly PluginLoader Instance = new PluginLoader();

        private MvxRoutingConfiguration _configuration = new MvxDefaultRoutingConfiguration();

        private bool _loaded;


        public void EnsureLoaded()
        {
            if (_loaded)
                return;

            _loaded = true;

            Mvx.LazyConstructAndRegisterSingleton(typeof(IMvxRoutingService), () =>
            {
                MvxRoutingService.LoadRoutes(_configuration.SourceAssemblies);
                return Mvx.IocConstruct<MvxRoutingService>();
            });
        }


        public void Configure(IMvxPluginConfiguration configuration)
        {
            if (!(configuration is MvxRoutingConfiguration))
                return;

            _configuration = (MvxRoutingConfiguration) configuration;
        }
    }
}
