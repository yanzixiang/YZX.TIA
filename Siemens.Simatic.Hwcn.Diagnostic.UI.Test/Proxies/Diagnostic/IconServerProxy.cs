using System.Collections.Generic;

using Siemens.Simatic.HwConfiguration.Diagnostic.Services;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services.Common;

namespace YZX.Tia.Proxies.Diagnostic
{
  public class IconServerProxy
  {
    IconServer IconServer;
    public IconServerProxy(IIconServer server)
    {
      IconServer = server as IconServer;
    }

    public IDictionary<string, object> GetIcons()
    {
      return IconServer.GetIcons();
    }

    public IDictionary<string, object> GetSmallIcons()
    {
      return IconServer.GetSmallIcons();
    }
  }
}
