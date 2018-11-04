using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Converter
{
  public static class OamConverters
  {
    internal static IOamAsyncResult ConnectAsyncResult2IOamAsyncResult(ConnectAsyncResult car)
    {
      return car;
    }
  }
}
