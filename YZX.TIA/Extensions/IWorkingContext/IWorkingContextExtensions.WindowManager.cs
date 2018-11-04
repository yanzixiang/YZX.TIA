using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;
using Siemens.Automation.FrameApplication.Navigation.Project.Main;

using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static IViewContent GetNavigationView([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.FrameApplication.ProjectNavigatorView") as ProjectNavigationView;
    }
    internal static ISlideManager GetSlideManager([NotNull] this IWorkingContext workingContext)
    {
      return (ISlideManager)workingContext.DlcManager.Load("Siemens.Automation.FrameApplication.WindowManager.SlidingManager", true);
    }
    public static SlidingManagerProxy GetSlideManagerProxy([NotNull] this IWorkingContext workingContext)
    {
      SlidingManager sm = workingContext.GetSlideManager() as SlidingManager;
      return new SlidingManagerProxy(sm);
    }
    internal static IWindowManagerInternal GetWindowManager([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<IWindowManagerInternal>("Siemens.Automation.FrameApplication.WindowManager");
    }

    public static WindowManagerProxy GetWindowManagerProxy([NotNull] this IWorkingContext workingContext)
    {
      return new WindowManagerProxy(workingContext.GetWindowManager());
    }
  }
}
