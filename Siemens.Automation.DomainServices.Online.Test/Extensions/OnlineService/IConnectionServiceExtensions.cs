
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.ConnectionService;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Extensions.OnlineService
{
  public static class IConnectionServiceExtensions
  {
    public static ConnectionServiceProvider ToConnectionServiceProvider(this IConnectionService ics)
    {
      if(ics is ConnectionServiceProvider)
      {
        return ics as ConnectionServiceProvider;
      }

      ConnectionServiceProvider csprovider = Reflector.GetInstanceFieldByName(ics, "m_RealConnectionService", ReflectionWays.SystemReflection) as ConnectionServiceProvider;
      return csprovider;
    }
  }
}
