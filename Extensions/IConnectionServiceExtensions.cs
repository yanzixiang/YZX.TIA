using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainModel;

using Reflection;

using YZX.Tia.Proxies.OnlineService;

namespace YZX.Tia.Extensions
{
  public static class IConnectionServiceExtensions
  {
    public static ConnectionServiceProvider ToConnectionServiceProvider(this IConnectionService ics)
    {
      if(ics is ConnectionServiceProvider)
      {
        return ics as ConnectionServiceProvider;
      }

      ConnectionServiceProxy csproxy = ics as ConnectionServiceProxy;
      ConnectionServiceProvider csprovider = Reflector.GetInstanceFieldByName(csproxy, "m_RealConnectionService", ReflectionWays.SystemReflection) as ConnectionServiceProvider;
      return csprovider;
    }

    public static ConnectionServiceProviderProxy ToProxy(this IConnectionService ics)
    {
      ConnectionServiceProvider csp = ics.ToConnectionServiceProvider();
      var proxy = new ConnectionServiceProviderProxy(csp);
      return proxy;
    }

    public static ICoreObject GetSimConnectionConfig(this IConnectionService ics)
    {
      var provider = ics.ToConnectionServiceProvider();
      var boardConfigurations = provider.GetUsableConfigurations("OMS");
      string str = "PLCSIM.TCPIP.1";
      foreach (ICoreObject o in boardConfigurations)
      {
        IOamIdentification attributes = CoreObjectExtension.GetAttributes<IOamIdentification>(o);
        if (attributes != null && attributes.OamName == str)
          return o;
      }
      return null;
    }
  }
}
