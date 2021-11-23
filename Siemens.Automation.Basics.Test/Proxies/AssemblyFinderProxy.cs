using System.Collections.Generic;
using System.Reflection;

using Siemens.Automation.Basics;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies
{
  public class AssemblyFinderProxy
  {
    public static IDictionary<string, Assembly> GetLoadedAssemblyList()
    {
      return Reflector.GetStaticFieldByName(typeof(AssemblyFinder),
        "s_LoadedAssemblyList",
        ReflectionWays.SystemReflection) as IDictionary<string, Assembly>;
    }
  }
}
