using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.FrameApplication;

using Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics;

using Reflection;

namespace YZX.Tia.Extensions.Hwcn
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
