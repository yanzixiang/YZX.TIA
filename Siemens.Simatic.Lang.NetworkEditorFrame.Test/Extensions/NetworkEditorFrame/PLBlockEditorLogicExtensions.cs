using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Automation.FrameApplication;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Extensions.NetworkEditorFrame
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
