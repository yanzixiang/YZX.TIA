using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.Model.DebugSupport;
using Siemens.Simatic.PlcLanguages.GraphBlockLogic;
using Siemens.Simatic.PlcLanguages.PLInterface.PLDebug;

namespace YZX.Tia.Proxies.Graph
{
  public class DebugManagerProxy
  {
    internal DebugManager DebugManager;
    internal DebugManagerProxy(DebugManager manager)
    {
      DebugManager = manager as DebugManager;
    }
    public GraphOperatingModeEnum GetOperatingMode()
    {
      return DebugManager.GetOperatingMode();
    }

    public bool GetGraphStatusData(string statusDataString, out IGraphStatusData graphStatusData)
    {
      return DebugManager.GetGraphStatusData(statusDataString, out graphStatusData);
    }

    public GraphOnlineService GraphOnlineService
    {
      get
      {
        return DebugManager.GraphOnlineService as GraphOnlineService;
      }
    }

    public AppendJobResult DeactivateStep(int stepNumber)
    {
      return GraphOnlineService.DeactivateStep(stepNumber);
    }

    public AppendJobResult ActivateStep(int stepNumber)
    {
      return GraphOnlineService.ActivateStep(stepNumber);
    }

    public AppendJobResult InitializeSequencer()
    {
      return GraphOnlineService.InitializeSequencer();
    }

    public AppendJobResult SwitchOffSequencer()
    {
      return GraphOnlineService.SwitchOffSequencer();
    }

    public AppendJobResult SwitchMode(GraphOperatingModeEnum newMode)
    {
      return GraphOnlineService.SwitchMode(newMode);
    }
  }
}
