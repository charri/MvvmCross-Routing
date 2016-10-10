using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charri.MvvmCross.Plugins.Routing;
using MvvmCross.Core.ViewModels;
using RoutingExample.Core.ViewModels;

[assembly: MvxRouting(typeof(TestAViewModel), @"mvx://test/a")]
[assembly: MvxRouting(typeof(TestAViewModel), @"https?://mvvmcross.com/blog")]
namespace RoutingExample.Core.ViewModels
{
    public class TestAViewModel
        : MvxViewModel
    {

        public TestAViewModel()
        {
            
        }

        public void Init()
        {
            
        }
    }
}
