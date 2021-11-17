using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OmsNodeControlProxy
  {
    private IOmsNodeControl NodeControl;

    public OmsNodeControlProxy(IOmsNodeControl nodeControl)
    {
      NodeControl = nodeControl;
    }
  }
}
