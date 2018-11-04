using Siemens.Automation.ObjectFrame;
using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Automation.DomainServices.ConnectionService;

using Reflection;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    private LegitimationServiceProvider m_LegitimationService;
    public LegitimationServiceProvider LegitimationService
    {
      get
      {
        if (m_LegitimationService == null)
        {
          ILegitimationService ils = projectWorkingContext.DlcManager.Load("Siemens.Automation.DomainServices.LegitimationService") as ILegitimationService;
          m_LegitimationService = ils as LegitimationServiceProvider;
        }
        return m_LegitimationService;
      }
    }

    public LegitimationServiceProvider GetLegitimationService(ICoreObject coreObject)
    {
      ILegitimationService legitimationService = null;
      if (!coreObject.IsDeleted || !coreObject.IsDeleting)
        legitimationService = ((IDlc)coreObject.Context).WorkingContext.DlcManager.Load("Siemens.Automation.DomainServices.LegitimationService") as ILegitimationService;
      return legitimationService as LegitimationServiceProvider;
    }

    public void ChangeLegitimationServiceObjectFactoryConnectionService(
      LegitimationServiceProvider lsp,
      ConnectionServiceProvider csp)
    {
      LegitimationServiceObjectFactory lsof = lsp.LegitimationServiceObjectFactory as LegitimationServiceObjectFactory;
      Reflector.SetInstanceFieldByName(
        lsof,
        "m_ConnectionService",
        csp,
        ReflectionWays.SystemReflection);
    }
  }
}
