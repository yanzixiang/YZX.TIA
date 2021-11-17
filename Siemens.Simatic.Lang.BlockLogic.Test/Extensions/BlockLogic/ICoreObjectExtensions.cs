using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.OMSPlus.Managed;
using Siemens.Simatic.PlcLanguages.BlockLogic.Online.OnlineReader;
using Siemens.Simatic.PlcLanguages.BlockLogic.Online.Plus.Upload;

namespace YZX.Tia.Extensions
{
  public static class ICoreObjectExtensions
  {
    internal static IOnlinePlusBlockAccess GetBlockAccess(ICoreObject target, ClientSession clientSession)
    {
      return OnlineBlockAccess.GetBlockAccess(target, clientSession);
    }

    internal static IOnlineReader GetOnlineReader(this ICoreObject onlineTarget)
    {
      return OnlineReaderFactory.GetOnlineReader(onlineTarget);
    }

    public static IUpload GetPlusBlockConsistencyService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      PlusBlockConsistencyService PlusBlockConsistencyService = idlcManager.Load("BlockLogic.PlusBlockConsistencyService")
        as PlusBlockConsistencyService;
      return PlusBlockConsistencyService;
    }
  }
}
