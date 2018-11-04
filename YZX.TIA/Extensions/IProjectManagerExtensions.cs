using Siemens.Automation.CommonServices;

using YZX.Tia.Proxies;

namespace YZX.Tia.Extensions
{
  public static class IProjectManagerExtensions
  {
    public static TiaProjectManagerProxy GetTiaProjectManagerProxy(this IProjectManager manager)
    {
      TiaProjectManagerLegacyHandlerProxy proxy = new TiaProjectManagerLegacyHandlerProxy(manager);
      return proxy.TiaProjectManagerProxy;
    }
  }
}
