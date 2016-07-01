using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace Charri.MvvmCross.Plugins.Routing
{
    /// <summary>
    /// Allows for URL base navigation in MvvmCross
    /// </summary>
    public interface IMvxRoutingService
    {
        /// <summary>
        /// Verifies if the provided URL can be converted to a ViewModel Request.
        /// </summary>
        /// <param name="url">URL to converted</param>
        /// <returns>True if the url can be converted or false if it cannot.</returns>
        bool CanRoute(string url);

        /// <summary>
        /// Translates the provided URL to a ViewModel Request and dispatches it.
        /// The ViewModel will be dispatched with MvxRequestedBy.Bookmark
        /// </summary>
        /// <param name="url">URL to converted</param>
        /// <returns>A task to await upon</returns>
        Task RouteAsync(string url);

        /// <summary>
        /// Translates the provided URL to a ViewModel Request and dispatches it.
        /// </summary>
        /// <param name="url">URL to converted</param>
        /// <param name="requestedBy"></param>
        /// <returns>A task to await upon</returns>
        Task RouteAsync(string url, MvxRequestedBy requestedBy);
    }
}
