using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public static class OamObjectCreatorProxy
  {
    public static int CreateAddress(string addressString, out IOamAddress address)
    {
      return OamObjectCreator.CreateAddress(addressString, out address);
    }
  }
}
