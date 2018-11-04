using Siemens.Simatic.PlcLanguages.BlockLogic.PLDebug;
using Siemens.Simatic.PlcLanguages.VatService;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class VatServiceExtensions
  {
    public static void SetDebugService(this VatService vs,DebugService ds)
    {
      Reflector.SetInstanceFieldByName(vs, "m_DebugService", ds,ReflectionWays.SystemReflection);
    }
  }
}
