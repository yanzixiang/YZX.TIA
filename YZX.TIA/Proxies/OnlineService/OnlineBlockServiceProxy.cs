using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Simatic.PlcLanguages.BlockLogic.Online;

namespace YZX.Tia.Proxies
{
  public class OnlineBlockServiceProxy
  {
    OnlineBlockService OnlineBlockService;
    public OnlineBlockServiceProxy(IOnlineBlockService IOnlineBlockService)
    {
      OnlineBlockService = IOnlineBlockService as OnlineBlockService;
    }

    internal TargetCache GetTargetCacheForTarget(ICoreObject target)
    {
      return OnlineBlockService.GetTargetCacheForTarget(target);
    }
  }
}
