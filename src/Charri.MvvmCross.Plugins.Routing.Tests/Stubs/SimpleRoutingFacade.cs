using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charri.MvvmCross.Plugins.Routing.Tests.TestArtefacts;
using MvvmCross.Core.ViewModels;

namespace Charri.MvvmCross.Plugins.Routing.Tests.Stubs
{
    public class SimpleRoutingFacade
        : IMvxRoutingFacade
    {
        public Task<MvxViewModelRequest> BuildViewModelRequest(string url,
            IDictionary<string, string> currentParameters, MvxRequestedBy requestedBy)
        {

            var viewModelType = currentParameters["vm"] == "a" ? typeof(ViewModelA) : typeof(ViewModelB);

            return Task.FromResult(new MvxViewModelRequest(viewModelType, new MvxBundle(), null, requestedBy));
        }
    }
}
