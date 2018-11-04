using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;

namespace YZX.Tia.Proxies
{
  public class BlockEditorLogicBaseProxy
  {
    BlockEditorLogicBase BELB;

    public BlockEditorLogicBaseProxy(BlockEditorLogicBase belb)
    {
      BELB = belb;
    }

    public void SkipPrintingTest()
    {


    }
  }
}
