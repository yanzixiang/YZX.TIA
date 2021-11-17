using System;

using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;

namespace YZX.Tia.Proxies.NetworkEditorFrame
{
  public class PLBlockEditorLogicProxy
  {
    PLBlockEditorLogic PLBlockEditorLogic;
    public PLBlockEditorLogicProxy(BlockEditorLogicBase logic)
    {
      PLBlockEditorLogic = logic as PLBlockEditorLogic;
    }
  }
}
