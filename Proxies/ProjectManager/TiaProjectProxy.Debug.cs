using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.BlockLogic.PLDebug;

namespace YZX.Tia.Proxies
{
  public partial class TiaProjectProxy
  {
    private DebugService m_DebugService = null;
    public DebugService DebugService
    {
      get
      {
        if (m_DebugService == null)
        {
          m_DebugService = new DebugService();
          IDlc dlc_DebugService = m_DebugService;
          dlc_DebugService.PreDetach();
          dlc_DebugService.Attach(ProjectWorkingContext);
          dlc_DebugService.PostAttach();
        }
        return m_DebugService;
      }
    }
  }
}
