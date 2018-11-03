using Siemens.Automation.OMSPlus.Managed;
using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OMSNodeProxy:OamNodeProxy
  {
    OMSNode OMSNode;

    public OMSNodeProxy(INode node) : base(node)
    {
      OMSNode = node as OMSNode;
    }

    public IConnection CreateConnection(OamConnectionType connectionType, bool useExisting)
    {
      return OMSNode.CreateConnection(connectionType, useExisting);
    }
    public IConnection CreateConnection(OamConnectionType connectionType, OmsSessionType sessionType)
    {
      return OMSNode.CreateConnection(connectionType, sessionType);
    }

    public ClientSession CreateOmsSession(OmsSessionType sessionType)
    {
      return OMSNode.CreateOmsSession(sessionType);
    }
  }
}
