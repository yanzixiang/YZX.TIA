using System.Net;

using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Simatic.HwConfiguration.Diagnostic.OnlineFunctions.Common;

namespace YZX.Tia.Extensions
{
  public static class IOamAddressExtensions
  {
    public static IPAddress ExtractIpAddress(this IOamAddress address)
    {
      return Helper.ExtractIpAddress(address);
    }
  }
}
