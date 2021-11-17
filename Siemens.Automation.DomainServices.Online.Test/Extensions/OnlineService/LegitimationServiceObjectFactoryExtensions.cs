using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace Siemens.Automation.DomainServices.Online.Test.Extensions
{
  public static class LegitimationServiceObjectFactoryExtensions
  {
    public static void ChangeLegitimationServiceObjectFactoryConnectionService(
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
