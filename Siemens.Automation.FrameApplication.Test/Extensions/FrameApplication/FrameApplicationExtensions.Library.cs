using System;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.Navigation.Library.GlobalLibrary;

using YZX.Tia.Proxies.FrameApplication;
using YZX.Tia.Dlc;

namespace YZX.Tia.Extensions.FrameApplication
{
  partial class FrameApplicationExtensions
  {
    public static GlobalLibraryNavigationViewProxy GetGlobalLibraryNavigationView(this IWorkingContext workingContext)
    {
      GlobalLibraryNavigationView dlc = workingContext.GetRequiredDlc<GlobalLibraryNavigationView>("Siemens.Automation.FrameApplication.Portal.Views.OpenProjectViewDlc");
      return new GlobalLibraryNavigationViewProxy(dlc);
    }
  }
}
