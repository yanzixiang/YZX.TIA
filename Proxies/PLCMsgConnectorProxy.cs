using Siemens.Simatic.PLCMessaging;


using Reflection;

namespace YZX.Tia.Proxies
{
  public class PLCMsgConnectorProxy
  {
    PLCMsgConnector PLCMsgConnector;

    public PLCMsgConnectorProxy(PLCMsgConnector connector)
    {
      PLCMsgConnector = connector;
    }
  }
}
