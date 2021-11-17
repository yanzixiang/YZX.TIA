using System;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;
using Siemens.Automation.FrameApplication.Navigation.Project.Main;

using YZX.Tia.Dlc;
using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions.FrameApplication
{
  public static class WindowManagerExtensions
  {
    public static IViewContent GetNavigationView(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.FrameApplication.ProjectNavigatorView") as ProjectNavigationView;
    }
    internal static ISlideManager GetSlideManager(this IWorkingContext workingContext)
    {
      return (ISlideManager)workingContext.DlcManager.Load("Siemens.Automation.FrameApplication.WindowManager.SlidingManager", true);
    }
    internal static SlidingManagerProxy GetSlideManagerProxy(this IWorkingContext workingContext)
    {
      SlidingManager sm = workingContext.GetSlideManager() as SlidingManager;
      return new SlidingManagerProxy(sm);
    }
    internal static IWindowManagerInternal GetWindowManager(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<IWindowManagerInternal>("Siemens.Automation.FrameApplication.WindowManager");
    }

    internal static WindowManagerProxy GetWindowManagerProxy(this IWorkingContext workingContext)
    {
      return new WindowManagerProxy(workingContext.GetWindowManager());
    }
  }
}
