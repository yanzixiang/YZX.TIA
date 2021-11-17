using Siemens.Automation.DomainServices;
using Siemens.Simatic.PlcLanguages.BlockLogic.Online.Plus.Upload;

namespace YZX.Tia.Proxies
{
  public class PlusBlockConsistencyServiceProxy
  {
    PlusBlockConsistencyService PlusBlockConsistencyService;
    public PlusBlockConsistencyServiceProxy(IUpload upload)
    {
      PlusBlockConsistencyService = upload as PlusBlockConsistencyService;
    }


  }
}
