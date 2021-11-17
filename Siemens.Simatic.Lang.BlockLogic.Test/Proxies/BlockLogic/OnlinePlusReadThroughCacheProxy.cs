using System;

using Siemens.Simatic.PlcLanguages.BlockLogic.Online.OnlineReader;

namespace YZX.Tia.Proxies
{
  public class OnlinePlusReadThroughCacheProxy
  {
    OnlinePlusReadThroughCache cache;

    internal OnlinePlusReadThroughCacheProxy(OnlinePlusReadThroughCache cache)
    {
      this.cache = cache;
    }
  }
}
