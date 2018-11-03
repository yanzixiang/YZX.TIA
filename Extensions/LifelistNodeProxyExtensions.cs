using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Automation.DomainServices.OnlineService;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class LifelistNodeProxyExtensions
  {
    public static INode GetPhysicalLifelistNode(this LifelistNodeProxy proxy)
    {
      return Reflector.RunInstanceMethodByName(proxy, "GetPhysicalLifelistNode", 
        ReflectionWays.SystemReflection) as INode;
    }
  }
}
