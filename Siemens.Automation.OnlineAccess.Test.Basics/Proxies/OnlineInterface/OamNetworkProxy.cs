using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamNetworkProxy
  {
    OamNetwork OamNetwork;
    public OamNetworkProxy(IOamNetwork network)
    {
      OamNetwork = network as OamNetwork;
    }

    OamNodeCollection Nodes
    {
      get
      {
        return OamNetwork.Nodes;
      }
    }

    List<OamScan> WaitingScans
    {
      get
      {
        return OamNetwork.WaitingScans;
      }
    }

    public static bool IsOpenTcpConnectionsActivated
    {
      get
      {
        return OamNetwork.IsOpenTcpConnectionsActivated;
      }
    }

    public int GetCountOfOnlineNodes()
    {
      return OamNetwork.GetCountOfOnlineNodes();
    }

    public void ClearOnlineNode()
    {
      OamNetwork.ClearOnlineNode();
    }

    public INode LookupOnlineNode(string searchedAddress)
    {
      return OamNetwork.LookupOnlineNode(searchedAddress);
    }
  }
}
