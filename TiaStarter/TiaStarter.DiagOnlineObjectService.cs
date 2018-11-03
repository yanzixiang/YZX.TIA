using Siemens.Simatic.HwConfiguration.Diagnostic.Services;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    IOnlineObjectService m_DiagOnlineObjectService;
    public IOnlineObjectService DiagOnlineObjectService
    {
      get
      {
        if (this.m_DiagOnlineObjectService == null)
        {
          this.m_DiagOnlineObjectService = projectWorkingContext.DlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineObjectService") as IOnlineObjectService;
          IOnlineObjectService onlineObjectService = this.m_DiagOnlineObjectService;
        }
        return this.m_DiagOnlineObjectService;
      }
    }
  }
}
