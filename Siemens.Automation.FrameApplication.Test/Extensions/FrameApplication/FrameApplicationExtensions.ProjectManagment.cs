using System;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.Portal.Views;
using Siemens.Automation.FrameApplication.ProjectHandling.PrimaryProject;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

using YZX.Tia.Proxies.FrameApplication;
using YZX.Tia.Dlc;

namespace YZX.Tia.Extensions.FrameApplication
{
  partial class FrameApplicationExtensions
  {
    public static OpenProjectViewDlcProxy GetOpenProjectViewDlc(this IWorkingContext workingContext)
    {
      var dlc = workingContext.GetRequiredDlc<OpenProjectViewDlc>("Siemens.Automation.FrameApplication.Portal.Views.OpenProjectViewDlc");
      return new OpenProjectViewDlcProxy(dlc);
    }

    public static PrimaryProjectUiWorkingContextManagerProxy GetPrimaryProjectUiWorkingContextManagerProxy(this IWorkingContext workingContext)
    {
      var dlc = workingContext.GetPrimaryProjectUiWorkingContextManagerDlc()
        as PrimaryProjectUiWorkingContextManagerDlc;
      var manager = Reflector.GetInstancePropertyByName(dlc, "Forwardee", ReflectionWays.SystemReflection)
        as PrimaryProjectUiWorkingContextManager;
      if (PrimaryProjectUiWorkingContextManagerProxy.Instance == null)
      {
        var proxy = new PrimaryProjectUiWorkingContextManagerProxy(manager);
        return proxy;
      }
      else
      {
        return PrimaryProjectUiWorkingContextManagerProxy.Instance;
      }
    }
  }
}
