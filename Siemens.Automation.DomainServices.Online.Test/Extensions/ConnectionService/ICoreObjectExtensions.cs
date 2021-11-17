using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

using YZX.Tia.Proxies.OnlineService;

namespace YZX.Tia.Extensions
{
  public static class ICoreObjectExtensions
  {
    public static ConnectionServiceProvider GetConnectionServiceProvider(this ICoreObject coreObject)
    {
      ConnectionServiceProvider connectionService = null;
      if (!coreObject.IsDeleted || !coreObject.IsDeleting)
      {
        IConnectionService ics = ((IDlc)coreObject.Context).WorkingContext.DlcManager.Load("Siemens.Automation.DomainServices.ConnectionService")
          as IConnectionService;
        ConnectionServiceProxy csp = ics as ConnectionServiceProxy;
        connectionService = Reflector.GetInstancePropertyByName(csp, "RealConnectionService", ReflectionWays.SystemReflection) as ConnectionServiceProvider;
      }
      return connectionService;
    }

    public static object GetNodeDetails(this ICoreObject node)
    {
      return LifelistNodeDetailsFactory.GetNodeDetails(node);
    }

    public static ICoreObject GetOnlineDeviceNode(this ICoreObject lifelistNode)
    {
      var detail = lifelistNode.GetNodeDetails();
      LifelistNodeDetailsProxy detailsProxy = new LifelistNodeDetailsProxy(detail);
      var onlineDevice = detailsProxy.OnlineDeviceNode;
      return onlineDevice;
    }
  }
}
