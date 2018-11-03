using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.HwConfiguration.Diagnostic.Common;
using Siemens.Simatic.PlcLanguages.BlockLogic.Online.OnlineReader;

namespace YZX.Tia.Extensions
{
  partial class ICoreObjectExtensions
  {
    public static string GetObjectIdentification(this ICoreObject source)
    {
      return Siemens.Simatic.HwConfiguration.Diagnostic.Common.Helper.GetObjectIdentification(source);
    }
    internal static IOnlineReader GetOnlineReader(this ICoreObject onlineTarget)
    {
      return OnlineReaderFactory.GetOnlineReader(onlineTarget);   
    }
  }
}
