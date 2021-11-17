using System;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.ProjectHandling.PrimaryProject;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions.FrameApplication
{
  public static class UiWorkingContextExtensions
  {
    public static IDlc GetPrimaryProjectUiWorkingContextManagerDlc(this IWorkingContext workingContext)
    {
      PrimaryProjectUiWorkingContextManagerDlc EditorController = 
        workingContext.DlcManager.Load("Siemens.Automation.FrameApplication.ProjectHandling.PrimaryProject.PrimaryProjectUiWorkingContextManager")
        as PrimaryProjectUiWorkingContextManagerDlc;
      return EditorController;
    }

    public static IUIContextHolder GetUIContextHolder(this IWorkingContext workingContext)
    {
      PrimaryProjectUiWorkingContextManagerDlc dlc = workingContext.GetPrimaryProjectUiWorkingContextManagerDlc()
        as PrimaryProjectUiWorkingContextManagerDlc;
      PrimaryProjectUiWorkingContextManager manager = Reflector.GetInstancePropertyByName(dlc, "Forwardee", ReflectionWays.SystemReflection)
        as PrimaryProjectUiWorkingContextManager;
      var proxy = new PrimaryProjectUiWorkingContextManagerProxy(manager);
      return proxy.IUIContextHolder;
    }
  }
}
