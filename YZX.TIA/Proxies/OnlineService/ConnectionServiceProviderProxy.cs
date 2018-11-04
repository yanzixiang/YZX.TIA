using System;
using System.Collections.Generic;

using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.DomainServices.ConnectionService.Private;

using Reflection;

namespace YZX.Tia.Proxies.OnlineService
{
  public class ConnectionServiceProviderProxy
  {
    public ConnectionServiceProvider ConnectionServiceProvider;

    public IOnlineConfiguration IOnlineConfiguration
    {
      get
      {
        return ConnectionServiceProvider;
      }
    }

    public ConnectionServiceProviderProxy(ConnectionServiceProvider csp)
    {
      ConnectionServiceProvider = csp;
    }

    public IAsyncResult BeginConnectToTarget(
      ConnectionParamsProxy connectParameter,
      AsyncCallback callback,
      object state)
    {
      IAsyncResult iar = Reflector.RunInstanceMethodByName(
        ConnectionServiceProvider,
        "BeginConnectToTarget",
        ReflectionWays.SystemReflection,
        connectParameter.CP,
        callback,
        state
        ) as IAsyncResult;
      return iar;
    }

    public event ConnectionOpenedEventHandler ConnectionOpened
    {
      add
      {
        IOnlineConfiguration.ConnectionOpened += value;
      }
      remove
      {
        IOnlineConfiguration.ConnectionOpened -= value;
      }
    }

    public ConnectionServiceClassFactoryProxy ClassFactory
    {
      get
      {
        IConnectionServiceClassFactory ClassFactory = Reflector.GetInstancePropertyByName(ConnectionServiceProvider,
          "ClassFactory", ReflectionWays.SystemReflection) as IConnectionServiceClassFactory;
        return new ConnectionServiceClassFactoryProxy(ClassFactory);
      }
    }

    public IOnlineService OnlineService
    {
      get
      {
        return Reflector.GetInstancePropertyByName(ConnectionServiceProvider,
          "OnlineService", ReflectionWays.SystemReflection) as IOnlineService;
      }
    }

    public List<ConnectorBaseProxy> ExistingConnectors
    {
      get
      {
        List<ConnectorBaseProxy> connectorList = new List<ConnectorBaseProxy>();
        IEnumerable<ConnectorBase> ecx = Reflector.GetInstancePropertyByName(ConnectionServiceProvider,
          "ExistingConnectors", ReflectionWays.SystemReflection) as IEnumerable<ConnectorBase>;
        foreach(ConnectorBase cb in ecx)
        {
          ConnectorBaseProxy cbp = new ConnectorBaseProxy(cb);
          connectorList.Add(cbp);
        }
        return connectorList;
      }
    }

    public ConnectorBaseProxy GetConnector(string connectionType)
    {
      ConnectorBase connectorBase = ConnectionServiceProvider.GetConnector(connectionType);
      return new ConnectorBaseProxy(connectorBase);
    }
  }
}
