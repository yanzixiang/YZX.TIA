using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Siemens.Automation.DomainServices;
using Siemens.Simatic.PlcLanguages.BlockLogic.Online.Plus.Upload;

using Reflection;

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
