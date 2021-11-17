using System.Collections.Generic;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;
using Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics;

namespace YZX.Tia.Extensions.Diagnostic
{
  public static class FrameGroupManagerExtensions
  {
    public static List<IDoeInstanceAccess> GetDoeInstances(this FrameGroupManager manager)
    {
      return Reflector.GetInstanceFieldByName(manager, "m_DoeInstances", ReflectionWays.SystemReflection)
       as List<IDoeInstanceAccess>;
    }

    public static string GetViewId(this FrameGroupManager manager)
    {
      return Reflector.GetInstanceFieldByName(manager, "m_ViewId", ReflectionWays.SystemReflection)
        as string;
    }
  }
}
