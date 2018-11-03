using System;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.ConnectionService;

using Reflection;

using YZX.Tia.Extensions;
using YZX.Tia.Proxies;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    private ConnectionServiceProvider m_ConnectionService;
    public ConnectionServiceProvider ConnectionService
    {
      get
      {
        if (this.m_ConnectionService == null)
        {
          IConnectionService ics = projectViewWorkingContext.DlcManager.Load("Siemens.Automation.DomainServices.ConnectionService") as IConnectionService;
          m_ConnectionService = ics.ToConnectionServiceProvider();
        }
        return this.m_ConnectionService;
      }
    }

    public IAsyncResult BeginConnectToTarget(
      ConnectionServiceProvider ssp,
      ConnectionParamsProxy connectParameter,
      AsyncCallback callback,
      object state)
    {
      return Reflector.RunInstanceMethodByName(
        ssp, 
        "BeginConnectToTarget", 
        ReflectionWays.SystemReflection,
        connectParameter.CP, 
        callback, 
        state) as IAsyncResult;
    }

    internal ConnectorBase GetConnector(
      ConnectionServiceProvider csp, 
      string connectionType)
    {
      return csp.GetConnector(connectionType);
    }

    public bool PrepareConnection(
      ConnectionServiceProvider csp,
      ICoreObject target, 
      string connectionType)
    {
      return csp.PrepareConnection(target, connectionType);
    }
  }
}
