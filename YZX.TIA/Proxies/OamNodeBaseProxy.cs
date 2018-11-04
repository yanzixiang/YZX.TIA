using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamNodeBaseProxy
  {
    OamNodeBase OamNodeBase;

    public OamNodeBaseProxy(INode node)
    {
      OamNodeBase = node as OamNodeBase;
    }
  }
}
