using Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Extensions.Diagnostic
{
  public static class DoeInstanceAccessExtensions
  {
    public static IDoeViewAccess GetDoeViewAccess(this IDoeInstanceAccess iaccess)
    {
      DoeInstanceAccess access = iaccess as DoeInstanceAccess;

      if (access != null)
      {

        return Reflector.GetInstanceFieldByName(access, "m_DoeViewAccess", ReflectionWays.SystemReflection)
          as IDoeViewAccess;
      }
      else
      {
        return null;
      }
    }
  }
}
