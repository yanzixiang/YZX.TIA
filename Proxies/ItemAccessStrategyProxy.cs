using Siemens.Automation.DomainServices.TagService;

using Reflection;

namespace YZX.Tia.Proxies
{
  public class ItemAccessStrategyProxy
  {
    ItemAccessStrategy IItemAccessStrategy;

    public ItemAccessStrategyProxy(object ias)
    {
      IItemAccessStrategy = ias as ItemAccessStrategy;
    }
  }
}
