using System;
using System.Collections.Generic;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Automation.OnlineAccess.SPS7;

using Reflection;

using YZX.Tia.Converter;

namespace YZX.Tia.Proxies
{
  public class SPS7ConnectionProxy:S7DOSConnectionProxy
  {
    SPS7Connection SPS7Connection;

    public SPS7ConnectionProxy(OamConnectionBase connection)
      :base(connection)
    {
      SPS7Connection = connection as SPS7Connection;
    }

    public List<IOamAsyncResult> SuspendedConnectRequests
    {
      get
      {
        List<ConnectAsyncResult> result = 
          Reflector.GetInstanceFieldByName(SPS7Connection,
          "",
          ReflectionWays.SystemReflection) as List<ConnectAsyncResult>;

        return result.ConvertAll(new Converter<ConnectAsyncResult, IOamAsyncResult>(
          OamConverters.ConnectAsyncResult2IOamAsyncResult));
      }
    }

    public IOamSystemNotifier NotifyWatchdogHandler
    {
      get
      {
        return SPS7Connection.NotifyWatchdogHandler;
      }
    }

    public OamOnlineBlockDirectoryProxy BlocksProxy
    {
      get
      {
        return new OamOnlineBlockDirectoryProxy(SPS7Connection.Blocks);
      }
    }
  }
}
