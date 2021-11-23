using Siemens.Automation.Basics;

namespace YZX.Tia.Proxies.Dlc
{
  public class DlcManagerProxy
  {
    DlcManager Manager;
    public DlcManagerProxy(IDlcManager manager)
    {
      Manager = manager as DlcManager;
    }


  }
}
