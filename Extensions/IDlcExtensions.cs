using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Simatic.HwConfiguration.Basics.Basics;

namespace YZX.Tia.Extensions
{
  public static class IDlcExtensions
  {
    public static ConnectionServiceProvider GetConnectionService([NotNull] this IDlcManager manager)
    {
      return manager.Load("Siemens.Automation.DomainServices.ConnectionService") as ConnectionServiceProvider;
    }
  }
}
