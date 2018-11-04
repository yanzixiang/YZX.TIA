using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class EthernetDiscoverConnectionProxy:S7DOSConnectionProxy
  {
    EthernetDiscoverConnection EthernetDiscoverConnection;

    public EthernetDiscoverConnectionProxy(OamConnectionBase connection)
      :base(connection)
    {
      EthernetDiscoverConnection = connection as EthernetDiscoverConnection;
    }

    public int DeletePgIpAdresses()
    {
      return EthernetDiscoverConnection.DeletePgIpAdresses();
    }
  }
}
