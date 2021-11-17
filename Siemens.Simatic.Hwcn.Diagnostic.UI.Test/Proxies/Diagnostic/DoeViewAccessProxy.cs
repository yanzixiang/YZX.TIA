using Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics;

namespace YZX.Tia.Proxies.Diagnostic
{
  public class DoeViewAccessProxy
  {
    internal DoeViewAccess DoeViewAccess;

    public DoeViewAccessProxy(IDoeViewAccess viewAccess)
    {
      DoeViewAccess = viewAccess as DoeViewAccess;
    }
  }
}
