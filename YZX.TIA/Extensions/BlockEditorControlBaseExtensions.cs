using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Siemens.Automation.FrameApplication;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Taskcards.Instruction;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class BlockEditorControlBaseExtensions
  {
    public static void SetFavouritesManager(this BlockEditorControlBase becb,
      FavouritesManager favouritesManager)
    {
      Reflector.SetInstanceFieldByName(becb, 
        "m_FavouritesManager", 
        favouritesManager, 
        ReflectionWays.SystemReflection); ;
    }
  }
}
