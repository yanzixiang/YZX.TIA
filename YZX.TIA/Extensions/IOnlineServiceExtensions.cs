using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.OnlineService;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class IOnlineServiceExtensions
  {
    public static OnlineServiceProvider ToOnlineServiceProvider(this IOnlineService ios)
    {
      OnlineServiceProxy osp = ios as OnlineServiceProxy;
      IOnlineService rios = Reflector.GetInstanceFieldByName(ios, "m_RealOnlineService", ReflectionWays.SystemReflection) as IOnlineService;
      OnlineServiceProvider real = rios as OnlineServiceProvider;
      return real;
    }
  }
}
