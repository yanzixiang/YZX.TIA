using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.ViewManager;

using Reflection;

using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static IViewManager GetViewManager([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.FrameApplication.ViewManager") as IViewManager;
    }

    public static ViewManagerProxy GetViewManagerProxy([NotNull] this IWorkingContext workingContext)
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
