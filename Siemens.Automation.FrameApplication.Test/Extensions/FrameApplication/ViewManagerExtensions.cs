using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.ViewManager;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions.FrameApplication
{
  public static class ViewManagerExtensions
  {
    public static IViewManager GetViewManager(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.FrameApplication.ViewManager") as IViewManager;
    }

    public static ViewManagerProxy GetViewManagerProxy(this IWorkingContext workingContext)
    {
      ViewManagerDlc dlc = workingContext.GetViewManager() as ViewManagerDlc;
      ViewManagerFacade facade = Reflector.GetInstanceFieldByName(dlc,
        "m_ViewManagerFacade",
        ReflectionWays.SystemReflection) as ViewManagerFacade;
      IViewManager manager = Reflector.GetInstanceFieldByName(facade,
        "m_ViewManager",
        ReflectionWays.SystemReflection) as IViewManager;
      ViewManagerProxy proxy = new ViewManagerProxy(manager);
      return proxy;
    }
  }
}
