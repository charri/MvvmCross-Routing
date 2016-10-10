# MvvmCross Routing Plugin

This plugin improves deep linking into MvvmCross applications by using URL based navigation.

The routing service supports multiple URIs per ViewModel as well as "RoutingFacades" that return the right ViewModel + parameters depending on the URI.

The solution is composed of:

* Routing Attribute (ViewModel/Facade, URI regex)
* RoutingFacades are constructed via Mvx.IocConstruct to profit from dependency injection
* RoutingService, registered as a singleton, uses IMvxViewDispatcher to show the viewmodels
* Necessary additions to Android (Activity.OnNewIntent) + iOS (AppDelegate.OpenUrl) (look a the example project for more infos)

You can also use this solution for triggering deeplink from outside the app:
* Register a custom scheme (i.e. "foo") in our app (look a the example project for me infos)
* Push-Messages: Depending on the status of the app you can pass a uri as the Notification Parameter, so when the app starts you can deep link directly to the view you want.


## Basic Example

Supply your routings as assembly attributes. I personally recommend putting them in the same file as the referenced ViewModel.
```cs
[assembly: MvxRouting(typeof(ViewModelA), @"mvx://test/\?id=(?<id>[A-Z0-9]{32})$")]

namespace *.ViewModels
{
    public class ViewModelA
        : MvxViewModel
    {

    	public void Init(string id) // you can use captured groups defined in the regex as parameters here
        {

        }

    }
}
```

Routing in a ViewModel.
```cs
public class MainViewModel : MvxViewModel
{
    private readonly IMvxRoutingService _routingService;

    public MainViewModel(IMvxRoutingService routingService)
    {
        _routingService = routingService;
    }

    private ICommand _showACommand;

    public ICommand ShowACommand
    {
        get
        {
            return _showACommand ?? (_showACommand = new MvxAsyncCommand(async () =>
            {
                await _routingService.RouteAsync("mvx://test/?id=" + Guid.NewGuid().ToString("N"));
            }));
        }
    }
}
```

## Facades

Say you are building a task app and depending on the type of task you want to show a different view. This is where RoutingFacades come in handy (there is only so much regular expressions can do for you).

mvx://task/?id=00000000000000000000000000000000 <-- this task is done, show read-only view (ViewModelA)
mvx://task/?id=00000000000000000000000000000001 <-- this task isn't, go straight to edit view (ViewModelB)

```cs

[assembly: MvxRouting(typeof(SimpleRoutingFacade), @"mvx://task/\?id=(?<id>[A-Z0-9]{32})$")]
namespace *.RoutingFacades
{
	public class SimpleRoutingFacade
	    : IMvxRoutingFacade
	{
	    public Task<MvxViewModelRequest> BuildViewModelRequest(string url,
	        IDictionary<string, string> currentParameters, MvxRequestedBy requestedBy)
	    {
	    	// you can load data from a database etc.
	    	// try not to do a lot of work here, as the user is waiting for the UI to do something ;)
	        var viewModelType = currentParameters["id"] == Guid.Empty.ToString("N") ? typeof(ViewModelA) : typeof(ViewModelB);

	        return Task.FromResult(new MvxViewModelRequest(viewModelType, new MvxBundle(), null, requestedBy));
	    }
	}
}
```

## License

The MIT License (MIT)

Copyright (c) 2014-2016 charri

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
