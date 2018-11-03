using Siemens.Simatic.PlcLanguages.BlockLogic.PLDebug;
using Siemens.Simatic.PlcLanguages.TisServer;

namespace YZX.Tia.Proxies
{
  public class DebugJobProxy
  {
    public DebugJob DebugJob;
    public DebugJobProxy(DebugJob dj)
    {
      DebugJob = dj;
    }

    public ITisJob TisJob
    {
      get
      {
        return DebugJob.TisJob;
      }
    }
  }
}
