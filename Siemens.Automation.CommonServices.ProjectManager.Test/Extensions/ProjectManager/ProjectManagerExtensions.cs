using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;
using Siemens.Automation.ProjectManager.Impl.Tia;

using YZX.Tia.Proxies.ProjectManager;

namespace YZX.Tia.Extensions.ProjectManager
{
  public static class ProjectManagerExtensions
  {
    public static TiaProjectManagerLegacyHandlerProxy GetProjectManagerProxy(this IWorkingContext workingContext)
    {
      return new TiaProjectManagerLegacyHandlerProxy(GetProjectManager(workingContext));
    }

    public static IProjectManager GetProjectManager(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<IProjectManager>("Siemens.Automation.CommonServices.ProjectManager");
    }

    internal static TiaProjectManager GetTiaProjectManager(this IWorkingContext workingContext)
    {
      ITiaProjectActionerFactory requiredDlc = workingContext.GetRequiredDlc<ITiaProjectActionerFactory>( 
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
