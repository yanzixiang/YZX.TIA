using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

using Siemens.Automation.DomainServices.UI.OnlineCommon;

using YZX.Tia.Proxies.OnlineService;

namespace YZX.Tia.Converter
{
  public static class OnlineServiceConverters
  {
    internal static OnlineCommonNodeProxy OnlineCommonNodeProxy(OnlineCommonNode node)
    {
      return new OnlineCommonNodeProxy(node);
    }
  }
}
