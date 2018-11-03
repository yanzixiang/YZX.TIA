using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamEthernetConnectionsWatcherProxy
  {
    private static OamEthernetConnectionsWatcherProxy s_Instance;
    public static OamEthernetConnectionsWatcherProxy Instance
    {
      get
      {
        if(s_Instance == null)
        {
          s_Instance = new OamEthernetConnectionsWatcherProxy(OamEthernetConnectionsWatcher.Instance);
        }
        return s_Instance;
      }
    }

    OamEthernetConnectionsWatcher OamEthernetConnectionsWatcher;
    internal OamEthernetConnectionsWatcherProxy(OamEthernetConnectionsWatcher watcher)
    {
      OamEthernetConnectionsWatcher = watcher;
    }

    public static OamEthernetConnectionsWatcherProxy Initialize()
    {
      return new OamEthernetConnectionsWatcherProxy(OamEthernetConnectionsWatcher.Initialize());
    }

    public int AddConnection(IEthernetDiscoverConnection edConnection)
    {
      return OamEthernetConnectionsWatcher.AddConnection(edConnection);
    }

    public void RemoveConnection(IEthernetDiscoverConnection edConnection)
    {
      OamEthernetConnectionsWatcher.RemoveConnection(edConnection);
    }

    public int PingEthernetNode(IEthernetDiscoverConnection connection)
    {
      EthernetDiscoverConnection edc = connection as EthernetDiscoverConnection;
      return OamEthernetConnectionsWatcher.PingEthernetNode(edc);
    }
  }
}
