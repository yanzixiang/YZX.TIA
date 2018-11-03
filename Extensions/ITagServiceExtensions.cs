using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.TagService;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class ITagServiceExtensions
  {
    internal static TagServiceCore GetTagServiceCore(this ITagService its)
    {
      object o = Reflector.GetInstanceFieldByName(its, "m_ServiceCore", ReflectionWays.SystemReflection);
      TagServiceCore tsc = o as TagServiceCore;
      return tsc;
    }
  }
}
