using Siemens.Automation.DomainServices;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public IOnlineCommandInvoke OnlineCommandInvoke
    {
      get
      {
        return projectWorkingContext.DlcManager.Load("Siemens.Automation.DomainServices.OnlineService.OnlineCommandInvoke") as IOnlineCommandInvoke;
      }
    }
  }
}
