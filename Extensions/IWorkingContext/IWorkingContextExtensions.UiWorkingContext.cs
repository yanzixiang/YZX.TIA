using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.ProjectHandling.PrimaryProject;

using Reflection;

using YZX.Tia.Proxies;
using Siemens.Automation.FrameApplication;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static IDlc GetPrimaryProjectUiWorkingContextManagerDlc([NotNull] this IWorkingContext workingContext)
    {
      PrimaryProjectUiWorkingContextManagerDlc EditorController = 
        workingContext.DlcManager.Load("Siemens.Automation.FrameApplication.ProjectHandling.PrimaryProject.PrimaryProjectUiWorkingContextManager")
        as PrimaryProjectUiWorkingContextManagerDlc;
      return EditorController;
    }

    public static PrimaryProjectUiWorkingContextManagerProxy GetPrimaryProjectUiWorkingContextManagerProxy([NotNull] this IWorkingContext workingContext)
    {
      PrimaryProjectUiWorkingContextManagerDlc dlc = workingContext.GetPrimaryProjectUiWorkingContextManagerDlc()
        as PrimaryProjectUiWorkingContextManagerDlc;
      PrimaryProjectUiWorkingContextManager manager = Reflector.GetInstancePropertyByName(dlc, "Forwardee", ReflectionWays.SystemReflection)
        as PrimaryProjectUiWorkingContextManager;
      PrimaryProjectUiWorkingContextManagerProxy proxy = new PrimaryProjectUiWorkingContextManagerProxy(manager);
      return proxy;
    }

    public static IUIContextHolder GetUIContextHolder([NotNull] this IWorkingContext workingContext)
    {
      PrimaryProjectUiWorkingContextManagerDlc dlc = workingContext.GetPrimaryProjectUiWorkingContextManagerDlc()
        as PrimaryProjectUiWorkingContextManagerDlc;
      PrimaryProjectUiWorkingContextManager manager = Reflector.GetInstancePropertyByName(dlc, "Forwardee", ReflectionWays.SystemReflection)
        as PrimaryProjectUiWorkingContextManager;
      PrimaryProjectUiWorkingContextManagerProxy proxy = new PrimaryProjectUiWorkingContextManagerProxy(manager);
      return proxy.IUIContextHolder;
    }
  }
}
