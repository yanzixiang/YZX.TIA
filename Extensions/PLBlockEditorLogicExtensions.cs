using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.Logic;
using Siemens.Automation.FrameApplication;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class PLBlockEditorLogicExtensions
  {
    public static void SetMenuService(this BlockEditorLogicBase PLlogic,
      IMenuService menuService)
    {
      Reflector.SetInstanceFieldByName(PLlogic, "m_MenuService", menuService, ReflectionWays.SystemReflection); ;
    }
  }
}
