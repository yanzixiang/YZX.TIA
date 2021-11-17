
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Simatic.SystemDiagnosis.Comm.OMSPlusService;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Extensions
{
  public static class OMSPlusConnectionServiceExtensions
  {
    public static void SetConnection(this OMSPlusConnectionService service,
      IOMSConnection connection)
    {
      Reflector.SetInstanceFieldByName(service,
        "m_Connection", connection, ReflectionWays.SystemReflection);
    }
  }
}
