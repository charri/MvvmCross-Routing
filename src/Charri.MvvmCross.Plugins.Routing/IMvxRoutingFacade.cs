using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace Charri.MvvmCross.Plugins.Routing
{
    public interface IMvxRoutingFacade
    {
        Task<MvxViewModelRequest> BuildViewModelRequest(string url, IDictionary<string, string> currentParameters, MvxRequestedBy requestedBy);
    }
}
