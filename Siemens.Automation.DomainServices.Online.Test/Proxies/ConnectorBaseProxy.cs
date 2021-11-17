using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.OnlineService
{
  public class ConnectorBaseProxy
  {
    ConnectorBase ConnectorBase;

    public ConnectorBaseProxy(object connectorBase)
    {
      ConnectorBase = connectorBase as ConnectorBase;
    }

    public virtual IConnection CreateDirectOamConnection(INode node, bool shareConnection)
    {
      return Reflector.RunInstanceMethodByName(ConnectorBase,
        "CreateDirectOamConnection", ReflectionWays.SystemReflection,
        node,
        shareConnection) as IConnection;
    }
  }
}
