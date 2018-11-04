using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.Navigation.Library.GlobalLibrary;

using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static GlobalLibraryNavigationViewProxy GetGlobalLibraryNavigationView([NotNull] this IWorkingContext workingContext)
    {
      GlobalLibraryNavigationView dlc = workingContext.GetRequiredDlc<GlobalLibraryNavigationView>("Siemens.Automation.FrameApplication.Portal.Views.OpenProjectViewDlc");
      return new GlobalLibraryNavigationViewProxy(dlc);
    }
  }
}
