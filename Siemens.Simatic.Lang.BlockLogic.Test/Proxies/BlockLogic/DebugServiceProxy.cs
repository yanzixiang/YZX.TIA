using System.ComponentModel;

using Siemens.Simatic.PlcLanguages.BlockLogic.PLDebug;

namespace YZX.Tia.Proxies
{
  public class DebugServiceProxy
  {
    public DebugService DebugService;

    public DebugServiceProxy(DebugService ds)
    {
      DebugService = ds;
    }

    public IDebugSynchronizeInvoke Synchronizer
    {
      get
      {
        return DebugService.Synchronizer;
      }
    }
  }
}
