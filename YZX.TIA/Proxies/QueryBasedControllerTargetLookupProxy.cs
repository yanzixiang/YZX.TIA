using Siemens.Simatic.PlcLanguages.BlockLogic.OpenBlockHandling;
using Siemens.Automation.ObjectFrame;

namespace YZX.Tia.Proxies
{
  public class QueryBasedControllerTargetLookupProxy
  {
    IControllerTargetLookup lookup;

    public QueryBasedControllerTargetLookupProxy(ICoreContext coreContext)
    {
      lookup = new QueryBasedControllerTargetLookup(coreContext);
    }

    public ICoreObject FindControllerTargetByName(string name)
    {
      return lookup.FindControllerTargetByName(name);
    }
  }
}
