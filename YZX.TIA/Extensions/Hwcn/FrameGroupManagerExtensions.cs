using Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Reflection;

namespace YZX.Tia.Extensions.Hwcn
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
