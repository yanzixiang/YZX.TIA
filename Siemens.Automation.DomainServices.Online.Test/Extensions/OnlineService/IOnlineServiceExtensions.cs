using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.OnlineService;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Extensions.OnlineService
{
  public static class IOnlineServiceExtensions
  {
    public static OnlineServiceProvider ToOnlineServiceProvider(this IOnlineService ios)
    {
      IOnlineService rios = Reflector.GetInstanceFieldByName(ios, "m_RealOnlineService", ReflectionWays.SystemReflection) as IOnlineService;
      OnlineServiceProvider real = rios as OnlineServiceProvider;
      return real;
    }

    public static OnlineServiceProvider GetOnlineService(this IWorkingContext workingContext)
    {
      IOnlineService ios = workingContext.DlcManager.Load("Siemens.Automation.DomainServices.OnlineService") as IOnlineService;

      return ios.ToOnlineServiceProvider();
    }
  }
}
