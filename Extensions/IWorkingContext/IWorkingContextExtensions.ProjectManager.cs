using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;
using Siemens.Automation.ProjectManager.Impl.Tia;

using YZX.Tia.Proxies;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static TiaProjectManagerLegacyHandlerProxy GetProjectManagerProxy(this IWorkingContext workingContext)
    {
      return new TiaProjectManagerLegacyHandlerProxy(GetProjectManager(workingContext));
    }

    public static IProjectManager GetProjectManager([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<IProjectManager>("Siemens.Automation.CommonServices.ProjectManager");
    }

    internal static TiaProjectManager GetTiaProjectManager(this IWorkingContext workingContext)
    {
      ITiaProjectActionerFactory requiredDlc = GetRequiredDlc<ITiaProjectActionerFactory>(workingContext, 
        "Siemens.Automation.ProjectManager.Impl.Tia.TiaProjectActionerFactory");
      return new TiaProjectManager(workingContext, requiredDlc);
    }

    public static TiaProjectManagerProxy GetTiaProjectManagerProxy(this IWorkingContext workingContext)
    {
      TiaProjectManager tiaProjectManager = workingContext.GetTiaProjectManager();
      TiaProjectManagerProxy tiaProjectManagerProxy = new TiaProjectManagerProxy(tiaProjectManager);
      return tiaProjectManagerProxy;
    }
  }
}
