using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Charri.MvvmCross.Plugins.Routing
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class MvxRoutingAttribute : Attribute
    {
        public Type ViewModelOrFacade { get; private set; }
        
        public string UrlRegex { get; private set; }

        public MvxRoutingAttribute(Type viewModelOrFacade, [RegexPattern] string urlRegex)
        {
            ViewModelOrFacade = viewModelOrFacade;
            UrlRegex = urlRegex;
        }
    }
}
