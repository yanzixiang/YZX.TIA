using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class DPSlaveConnectionProxy:S7DOSConnectionProxy
  {
    DPSlaveConnection DPSlaveConnection;
    public DPSlaveConnectionProxy(OamConnectionBase connection):
      base(connection)
    {
      DPSlaveConnection = connection as DPSlaveConnection;
    }
  }
}
